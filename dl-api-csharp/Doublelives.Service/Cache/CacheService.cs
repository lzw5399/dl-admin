using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Doublelives.Infrastructure.Extensions;
using Doublelives.Shared.ConfigModels;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Doublelives.Service.Cache
{
    public class CacheService : ICacheService
    {
        private static readonly Dictionary<string, int> CacheKeyNTimes = new Dictionary<string, int>();
        private static object _lockObj = new object();
        private readonly CacheOptions _cacheOptions;
        private readonly IDistributedCache _cache;

        public CacheService(IOptions<CacheOptions> options, IDistributedCache cache)
        {
            _cacheOptions = options.Value;
            _cache = cache;
        }

        public async Task<T> GetOrCreateAsync<T>(string cacheKey, Func<DistributedCacheEntryOptions, Task<T>> factory)
        {
            int cacheTime = _cacheOptions.DefaultExpireMinutes;
            if (IsCacheTimeChanged(cacheKey, cacheTime))
            {
                Remove(cacheKey);
            }
            AddCacheKey(cacheKey, cacheTime);

            return await _cache.GetOrCreateAsync(cacheKey, async entry =>
            {
                entry.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(cacheTime);
                return await factory(entry);
            });
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
            if (!CacheKeyNTimes.ContainsKey(cacheKey)) return false;
            var oldCacheTime = CacheKeyNTimes[cacheKey];

            return oldCacheTime != cacheTime;
        }

        private static void AddCacheKey(string cachekey, int time = 1)
        {
            if (CacheKeyNTimes.ContainsKey(cachekey)) return;
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