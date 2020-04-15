using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Doublelives.Infrastructure.Extensions
{
    public static class DistributedCacheExtension
    {
        public static T GetAsObject<T>(this IDistributedCache cache, string key)
        {
            var result = cache.GetString(key);

            if (result == null)
            {
                return default;
            }

            return JsonConvert.DeserializeObject<T>(result);
        }

        public static void SetAsObject(this IDistributedCache cache, string key, object obj)
        {
            var str = JsonConvert.SerializeObject(obj);
            cache.SetString(key, str, new DistributedCacheEntryOptions { SlidingExpiration = TimeSpan.FromDays(7) });
        }
        
        public static async Task<TItem> GetOrCreateAsync<TItem>(
            this IDistributedCache cache,
            string key,
            Func<ICacheEntry, Task<TItem>> factory)
        {
            var obj = cache.GetAsObject<TItem>(key);
            if (obj != null) return obj;

            
            return await factory(key);
        }
    }
}
