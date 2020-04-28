using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading.Tasks;

namespace Doublelives.Infrastructure.Cache
{
    public interface ICacheManager
    {
        Task<T> GetOrCreateAsync<T>(string cacheKey, Func<CacheEntryOptions, Task<T>> factory);

        bool CreateOrUpdate<T>(string cacheKey, T cacheValue, CacheEntryOptions options = null);

        bool Remove(string cacheKey);

        bool Exist(string cacheKey);

        /// <summary>
        /// 清空所有缓存
        /// </summary>
        void Flushall();
    }
}
