using Doublelives.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doublelives.Service.Cache
{
    public interface ICacheManager
    {
        Task<List<T>> GetOrCreatePagedListAsync<T>(SearchCriteria criteria,
            Func<CacheEntryOptions, Task<List<T>>> factory) where T : EntityBase;

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