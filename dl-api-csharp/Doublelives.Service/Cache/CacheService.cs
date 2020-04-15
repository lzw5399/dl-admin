using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Doublelives.Shared.ConfigModels;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace Doublelives.Service.Cache
{
    public class CacheService : ICacheService
    {
        public static Dictionary<string, int> CacheKeyNTimes = new Dictionary<string, int>();
        private static object _lockObj = new object();
        private readonly CacheOptions _cacheOptions;
        private readonly IDistributedCache _cache;
        
        public CacheService(CacheOptions cacheOptions,IDistributedCache cache)
        {
            _cacheOptions = cacheOptions;
            _cache = cache;
        }
        
        public async Task<T> GetOrCreateAsync<T>(string cacheKey, Func<ICacheEntry, Task<T>> factory)
        {
            int cacheTime = _cacheOptions.DefaultExpireMinutes;
            if (IsCacheTimeChanged(cacheKey, cacheTime))
            {
                Remove(cacheKey);
            }
            AddCacheKey(cacheKey, cacheTime);

            return await _cache.GetOrCreateAsync(cacheKey, async entry =>
            {
                entry.AbsoluteExpiration = DateTimeOffset.Now.AddHours(cacheTime);
                return await factory(entry);
            });
        }

        public void Remove(List<string> cacheKeys)
        {
            lock (_lockObj)
            {
                foreach (var cacheKey in cacheKeys)
                {
                    CacheKeyNTimes.Remove(cacheKey);
                }
            }

            foreach (var cacheKey in cacheKeys)
            {
                _cache.Remove(cacheKey);
            }
        }

        public void Remove(string cacheKey)
        {
            lock (_lockObj)
            {
                CacheKeyNTimes.Remove(cacheKey);
            }
            _cache.Remove(cacheKey);
        }

        private bool IsCacheTimeChanged(string cacheKey, int cacheTime)
        {
            if (CacheKeyNTimes.ContainsKey(cacheKey))
            {
                var oldCacheTime = CacheKeyNTimes[cacheKey];

                return oldCacheTime != cacheTime;
            }

            return false;
        }

        private static void AddCacheKey(string cachekey, int time = 1)
        {
            if (!CacheKeyNTimes.ContainsKey(cachekey))
            {
                lock (_lockObj)
                {
                    if (!CacheKeyNTimes.ContainsKey(cachekey))
                    {
                        CacheKeyNTimes[cachekey] = time;
                    }
                }
            }
        }
    }
}