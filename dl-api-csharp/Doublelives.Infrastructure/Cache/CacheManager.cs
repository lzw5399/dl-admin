using CSRedis;
using Doublelives.Shared.ConfigModels;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doublelives.Infrastructure.Cache
{
    public class CacheManager : ICacheManager
    {
        private readonly CacheOptions _cacheOptions;
        private readonly CSRedisClient _redisClient;

        public CacheManager(IOptions<CacheOptions> options, CSRedisClient client)
        {
            _cacheOptions = options.Value;
            _redisClient = client;
        }

        /// <summary>
        /// 获取或添加缓存
        /// </summary>
        /// <typeparam name="T">获取的结果类型</typeparam>
        /// <param name="cacheKey">缓存key</param>
        /// <param name="factory">若缓存没有命中，执行的获取数据的方法</param>
        /// <returns></returns>
        public async Task<T> GetOrCreateAsync<T>(string cacheKey, Func<CacheEntryOptions, Task<T>> factory)
        {
            var entry = GetDefaultCacheEntryOptions();

            // 如果不启用cache直接请求
            if (!_cacheOptions.Enable)
                return await factory(entry);

            if (string.IsNullOrEmpty(cacheKey))
                throw new ArgumentNullException(nameof(cacheKey));

            if (factory == null)
                throw new ArgumentNullException(nameof(factory));

            var value = _redisClient.Get<T>(cacheKey);

            if (value != null)
                return value;

            value = await factory(entry);

            if (value == null)
                return default;

            _redisClient.Set(cacheKey, value, entry.Expire);

            return value;
        }

        /// <summary>
        /// 添加或更新
        /// </summary>
        /// <param name="cacheKey">缓存Key</param>
        /// <param name="cacheValue">要缓存的对象</param>
        public bool CreateOrUpdate<T>(string cacheKey, T cacheValue, CacheEntryOptions options = null)
        {
            if (string.IsNullOrEmpty(cacheKey))
                throw new ArgumentNullException(nameof(cacheKey));

            if (cacheValue == null)
                throw new ArgumentNullException(nameof(cacheValue));

            options ??= GetDefaultCacheEntryOptions();

            return _redisClient.Set(cacheKey, cacheValue, options.Expire);
        }

        /// <summary>根据key移除缓存</summary>
        public bool Remove(string cacheKey)
        {
            return _redisClient.Del(cacheKey) > 0 ? true : false;
        }

        public bool Exist(string cacheKey)
        {
            return _redisClient.Exists(cacheKey);
        }

        /// <summary>清空缓存</summary>
        public void Flushall()
        {
            var keys = _redisClient.Keys("*");

            foreach (var key in keys)
            {
                _redisClient.Del(key);
            }
        }

        private CacheEntryOptions GetDefaultCacheEntryOptions()
        {
            return new CacheEntryOptions
            {
                Expire = TimeSpan.FromMinutes(_cacheOptions.DefaultExpireMinutes)
            };
        }
    }
}
