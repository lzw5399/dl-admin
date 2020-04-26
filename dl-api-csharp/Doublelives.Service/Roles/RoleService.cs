using Doublelives.Domain.Sys;
using Doublelives.Infrastructure.Cache;
using Doublelives.Infrastructure.Helpers;
using Doublelives.Persistence;
using Doublelives.Shared.Constants;
using System.Collections.Generic;
using System.Linq;

namespace Doublelives.Service.Roles
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheManager _cacheManager;

        public RoleService(
            IUnitOfWork unitOfWork,
            ICacheManager cacheManager)
        {
            _unitOfWork = unitOfWork;
            _cacheManager = cacheManager;
        }

        public SysRole GetById(int id)
        {
            var result = _cacheManager.GetOrCreateAsync(GetRoleCacheKey(id), async entry =>
            {
                return await _unitOfWork.RoleRepository.GetByIdAsync(id);
            }).Result;

            return result;
        }

        public List<SysRole> GetListByIds(List<int> ids)
        {
            // e.g. role_list_1_2
            var key = GetRoleCacheKey($"list_{string.Join('_', ids)}");
            var result = _cacheManager.GetOrCreateAsync(key, async entry =>
             {
                 return (await _unitOfWork.RoleRepository.GetByIdsAsync(ids.ToArray())).ToList();
             }).Result;

            return result;
        }

        public List<SysRole> List()
        {
            throw new System.NotImplementedException();
        }

        private string GetRoleCacheKey(object reference)
        {
            // 代表所有的
            if (reference == null) return CacheHelper.ToCacheKey(CacheKeyPrefix.ROLE_CACHE_PREFIX, "all");

            // reference代表id, 单独某个
            return CacheHelper.ToCacheKey(CacheKeyPrefix.ROLE_CACHE_PREFIX, reference);
        }
    }
}
