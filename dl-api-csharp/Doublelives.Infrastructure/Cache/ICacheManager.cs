using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Doublelives.Infrastructure.Cache
{
    public interface ICacheManager
    {
        Task<T> GetOrCreateAsync<T>(string cacheKey, Func<DistributedCacheEntryOptions, Task<T>> factory);

        void Remove(string cacheKey);
    }
}
