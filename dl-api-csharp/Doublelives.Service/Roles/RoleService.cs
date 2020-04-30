using Doublelives.Domain.Sys;
using Doublelives.Domain.Sys.Dto;
using Doublelives.Infrastructure.Extensions;
using Doublelives.Infrastructure.Helpers;
using Doublelives.Persistence;
using Doublelives.Service.Cache;
using Doublelives.Service.Depts;
using Doublelives.Service.Mappers;
using Doublelives.Shared.Constants;
using Doublelives.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Doublelives.Service.Roles
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheManager _cacheManager;
        private readonly IDeptService _deptService;

        public RoleService(
            IUnitOfWork unitOfWork,
            ICacheManager cacheManager,
            IDeptService deptService)
        {
            _unitOfWork = unitOfWork;
            _cacheManager = cacheManager;
            _deptService = deptService;
        }

        public SysRole GetById(int id)
        {
            var result = _cacheManager.GetOrCreateAsync(GetRoleCacheKey(id),
                async entry => { return await _unitOfWork.RoleRepository.GetByIdAsync(id); }).Result;

            return result;
        }

        public List<SysRole> GetListByIds(List<int> ids)
        {
            // e.g. role_list_1_2
            var key = GetRoleCacheKey($"list_{string.Join('_', ids)}");
            var result = _cacheManager.GetOrCreateAsync(key,
                    async entry => { return (await _unitOfWork.RoleRepository.GetByIdsAsync(ids.ToArray())).ToList(); })
                .Result;

            return result;
        }

        public PagedModel<RoleProfileDto> GetPagedList(RoleSearchDto criteria)
        {
            Expression<Func<SysRole, bool>> condition = it => true;

            if (!string.IsNullOrWhiteSpace(criteria.RoleName))
                condition = condition.And(it =>
                    it.Name.Contains(criteria.RoleName) || it.Tips.Contains(criteria.RoleName));

            var result = _unitOfWork.RoleRepository.Paged(
                criteria.Page,
                criteria.Limit,
                condition,
                it => it.Id,
                true);

            var dto = RoleMapper.ToRoleProfileDto(result);

            if (dto.Count <= 0) return dto;

            foreach (var item in dto.Data)
            {
                var dept = _deptService.GetById(item.Deptid.Value());
                item.DeptName = dept?.Simplename;

                if (!item.Pid.HasValue || item.Pid.Value == 0) continue;

                // 先从已有的列表里面获取，如果有就不再单独去取
                if (dto.Data.Any(it => it.Id == item.Pid))
                {
                    item.PName = dto.Data.First(it => it.Id == item.Pid).Name;
                    continue;
                }

                // 单独取
                item.PName = GetById(item.Pid.Value)?.Name;
            }

            return dto;
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