using Doublelives.Domain.Sys;
using Doublelives.Domain.Sys.Dto;
using Doublelives.Infrastructure.Extensions;
using Doublelives.Persistence;
using Doublelives.Service.Cache;
using Doublelives.Service.Mappers;
using Doublelives.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Doublelives.Service.Dicts
{
    public class DictService : IDictService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheManager _cacheManager;

        public DictService(IUnitOfWork unitOfWork, ICacheManager cacheManager)
        {
            _unitOfWork = unitOfWork;
            _cacheManager = cacheManager;
        }

        public async Task<PagedModel<DictDto>> GetPagedList(DictSearchDto criteria)
        {
            // 列表只显示id为0的dict，其他的是以"子节点"来显示的
            Expression<Func<SysDict, bool>> condition = it => it.Pid == 0;

            if (!string.IsNullOrWhiteSpace(criteria.Name))
                condition = condition.And(it => it.Name.Contains(criteria.Name));

            var all = await GetAll();
            var topDict = all
                .Where(condition.Compile())
                .Skip((criteria.Page - 1) * criteria.Limit)
                .Take(criteria.Limit)
                .ToList();

            var dto = DictMapper.ToDictProfileDto(all, topDict, criteria);

            if (dto.Count <= 0) return dto;

            foreach (var item in dto.Data)
            {
                var sub = all.Where(it => it.Pid == item.Id).OrderBy(it => it.Num).ToList();

                if (sub.Count <= 0) continue;

                item.Detail = string.Join(',', sub.Select(it => string.Join(':', it.Num, it.Name)).ToList());
            }

            return dto;
        }

        /// <summary>
        /// 获取所有
        /// </summary>
        public async Task<List<SysDict>> GetAll()
        {
            var result = await _cacheManager.GetOrCreateAsync("dict_all",
                async entry => { return await _unitOfWork.DictRepository.GetAsQueryable().ToListAsync(); });

            return result;
        }
    }
}