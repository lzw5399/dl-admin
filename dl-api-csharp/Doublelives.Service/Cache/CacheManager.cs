using CSRedis;
using Doublelives.Domain.Infrastructure;
using Doublelives.Infrastructure.Extensions;
using Doublelives.Persistence;
using Doublelives.Shared.ConfigModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Doublelives.Service.Cache
{
    public class CacheManager : ICacheManager
    {
        private readonly CacheOptions _cacheOptions;
        private readonly CSRedisClient _redisClient;
        private readonly DlAdminDbContext _dbContext;
        private const int QUERY_PER_ROUND = 10000;

        public CacheManager(IOptions<CacheOptions> options, CSRedisClient client, DlAdminDbContext dbContext)
        {
            _cacheOptions = options.Value;
            _redisClient = client;
            _dbContext = dbContext;
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
        ///整张表缓存的一个封装，从缓存获取分页数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public async Task<List<T>> GetOrCreatePagedListAsync<T>(SearchCriteria criteria) where T : EntityBase
        {
            if (!_cacheOptions.Enable)
            {
                return await GetPagedFromDbAsync<T>(criteria);
            }

            // 如果包含模糊查询
            if (criteria.FuzzySearch)
                return await GetPagedListWithFuzzySearch<T>(criteria);

            // 整个是没有模糊查询的过程
            var ids = await _redisClient.ZRangeByLexAsync($"{typeof(T).Name}_ids", "-", "+", criteria.Count,
                criteria.Offset);

            if (!ids.Any())
                return await GetPagedListAndTriggerCacheFiller<T>(criteria);

            var list = await _redisClient.HMGetAsync<T>($"{typeof(T).Name}_all", ids);

            if (!list.Any() || ids.Count() != list.Count())
                return await GetPagedListAndTriggerCacheFiller<T>(criteria);

            return list.ToList();
        }

        public void SetWholeTableToCache<T>() where T : EntityBase
        {
            Task.Run(async () =>
            {
                var data = await _dbContext.Set<T>().ToListAsync();
                var ids = data.Select(it => ((decimal) it.Id, (object) it.Id)).ToArray();
                var mixed = data.SelectMany(it => new object[] {it.Id, it}).ToArray();

                // 将id添加到zrange(就是sorted set)
                await _redisClient.ZAddAsync($"{typeof(T).Name}_ids", ids);

                await _redisClient.HMSetAsync($"{typeof(T).Name}_all", mixed);
            }).Wait();
        }

        /// <summary>
        /// 获取带模糊搜索的分页结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="criteria"></param>
        /// <returns></returns>
        private async Task<List<T>> GetPagedListWithFuzzySearch<T>(SearchCriteria criteria) where T : EntityBase
        {
            var finalResult = new List<T>();
            var notenough = true;
            var round = 0;

            // 模糊查询
            var ids = await _redisClient.ZRangeAsync($"{typeof(T).Name}_ids", int.MaxValue, 0);

            while (notenough)
            {
                // 每次取1w个ids
                var tempids = ids.Skip(QUERY_PER_ROUND * round).Take(QUERY_PER_ROUND).ToArray();
                // 根据1w个ids获取具体的list
                var list = await _redisClient.HMGetAsync<T>($"{typeof(T).Name}_all", tempids);
                // 根据具体的1w个list，来模糊查询
                var matchData = list
                    .Where(GetPagedConditionExpression<T>(criteria).Compile())
                    .ToList();

                // 符合条件的，加入到最终的list中
                finalResult.AddRange(matchData);

                // 如果最终list的数量符合，或者ids的数量少于【(当前轮数+1)*1W】说明整张表不超过这个数
                // 直接返回分页的
                if (finalResult.Count >= criteria.Offset + criteria.Count ||
                    ids.Count() <= QUERY_PER_ROUND * (round + 1))
                {
                    notenough = false;
                }
                else
                {
                    round += 1;
                }
            }

            return finalResult.Skip(criteria.Offset).Take(criteria.Count).ToList();
        }

        private async Task<List<T>> GetPagedListAndTriggerCacheFiller<T>(SearchCriteria criteria) where T : EntityBase
        {
            var data = await GetPagedFromDbAsync<T>(criteria);

            // todo 触发filler

            return data;
        }

        private async Task<List<T>> GetPagedFromDbAsync<T>(SearchCriteria criteria) where T : EntityBase
        {
            var expression = GetPagedConditionExpression<T>(criteria);

            var list = await _dbContext.Set<T>()
                .Where(expression)
                .Skip(criteria.Offset)
                .Take(criteria.Count)
                .ToListAsync();

            return list;
        }

        private Expression<Func<T, bool>> GetPagedConditionExpression<T>(SearchCriteria criteria)
        {
            Expression<Func<T, bool>> expression = it => true;

            if (!criteria.FuzzySearch) return expression;

            foreach (var field in criteria.SearchFields)
            {
                expression = expression.AndCondition(field, criteria.Keyword, ConditionType.Like);
            }

            return expression;
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