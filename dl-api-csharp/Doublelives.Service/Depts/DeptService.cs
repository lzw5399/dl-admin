using Doublelives.Domain.Sys;
using Doublelives.Domain.Sys.Dto;
using Doublelives.Infrastructure.Helpers;
using Doublelives.Persistence;
using Doublelives.Service.Cache;
using Doublelives.Service.Mappers;
using Doublelives.Shared.Constants;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Doublelives.Service.Depts
{
    public class DeptService : IDeptService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheManager _cacheManager;

        public DeptService(
            IUnitOfWork unitOfWork,
            ICacheManager cacheManager)
        {
            _unitOfWork = unitOfWork;
            _cacheManager = cacheManager;
        }

        /// <summary>获取所有的部门树</summary>
        public List<DeptDto> List()
        {
            var result = _cacheManager.GetOrCreateAsync(GetDeptCacheKey(), async entry =>
            {
                var dtos = new List<DeptDto>();
                var depts = await _unitOfWork.DeptRepository.GetAsQueryable().ToListAsync();

                if (!depts.Any()) return dtos;

                var allDeptNodes = depts.Select(it => DeptMapper.ToDeptDto(it)).ToList();
                // 遍历所有的node
                foreach (var deptNode in allDeptNodes)
                {
                    var parentDept = allDeptNodes.FirstOrDefault(x => x.Id == deptNode.Pid);
                    // 如果当前节点的父节点不为空,说明不是顶层节点
                    if (parentDept != null)
                        parentDept.Children.Add(deptNode);
                    // 为空,说明当前节点为顶层节点
                    else
                        dtos.Add(deptNode);
                }

                return dtos;
            }).Result;

            return result;
        }

        public SysDept GetById(int id)
        {
            var result = _cacheManager.GetOrCreateAsync(GetDeptCacheKey(id), async entry =>
            {
                return await _unitOfWork.DeptRepository.GetByIdAsync(id);
            }).Result;

            return result;
        }

        private string GetDeptCacheKey(int? id = null)
        {
            // 代表所有的
            if (!id.HasValue) return CacheHelper.ToCacheKey(CacheKeyPrefix.DEPT_CACHE_PREFIX, "all");

            //value代表id, 单独某个
            return CacheHelper.ToCacheKey(CacheKeyPrefix.DEPT_CACHE_PREFIX, id);
        }
    }
}
