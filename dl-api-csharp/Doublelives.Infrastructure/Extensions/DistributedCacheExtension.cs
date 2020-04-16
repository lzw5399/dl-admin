using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Doublelives.Infrastructure.Extensions
{
    public static class DistributedCacheExtension
    {
        public static T GetAsObject<T>(this IDistributedCache cache, string key)
        {
            var result = cache.GetString(key);

            return result == null ? default : JsonConvert.DeserializeObject<T>(result);
        }

        public static void SetAsObject(this IDistributedCache cache, string key, object obj,
            DistributedCacheEntryOptions options = null)
        {
            if (options == null) options = new DistributedCacheEntryOptions();

            var str = JsonConvert.SerializeObject(obj);
            cache.SetString(key, str, options);
        }

        public static void SetAsObject(this IDistributedCache cache, Guid key, object obj,
            DistributedCacheEntryOptions options = null)
        {
            cache.SetAsObject(key.ToString(), obj, options);
        }

        /// <summary>
        /// 仿照memoryCache.GetOrCreateAsync的IDistributedCache版本
        /// </summary>
        public static async Task<TItem> GetOrCreateAsync<TItem>(
            this IDistributedCache cache,
            string key,
            Func<DistributedCacheEntryOptions, Task<TItem>> factory)
        {
            // 先从缓存中获取，有就直接返回
            var obj = cache.GetAsObject<TItem>(key);
            if (obj != null) return obj;
            var entry = new DistributedCacheEntryOptions();

            // 没有的话，取了再添加到缓存里面
            var result = await factory(entry);
            cache.SetAsObject(key, result, entry);

            return result;
        }
    }
}