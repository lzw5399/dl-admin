using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Doublelives.Service.Cache
{
    public interface ICacheService
    {
        Task<T> GetOrCreateAsync<T>(string cacheKey, Func<ICacheEntry, Task<T>> factory);

        void Remove(string cacheKey);

        void RemoveList(List<string> cacheKeys);
    }
}