using Doublelives.Domain.Sys;
using Doublelives.Domain.Sys.Dto;
using Doublelives.Infrastructure.Extensions;
using Doublelives.Persistence;
using Doublelives.Service.Cache;
using Doublelives.Service.Mappers;
using Doublelives.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Doublelives.Service.Cfgs
{
    public class CfgService : ICfgService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheManager _cacheManager;

        public CfgService(IUnitOfWork unitOfWork, ICacheManager cacheManager)
        {
            _unitOfWork = unitOfWork;
            _cacheManager = cacheManager;
        }

        public async Task<PagedModel<CfgDto>> GetPagedList(CfgSearchDto criteria)
        {
            var searchCriteria = new SearchCriteria
            {
                Keyword = criteria.CfgName,
                SearchFields = new string[] {"CfgName"},
                Offset = (criteria.Page -1) * criteria.Limit,
                Count = criteria.Limit
            };
            var result = await _cacheManager.GetOrCreatePagedListAsync<SysCfg>(searchCriteria, async options =>
            {
                return new List<SysCfg>();
            });
           
            var dto = CfgMapper.ToCfgDto(new PagedModel<SysCfg>());

            return dto;
        }

        public async Task<PagedModel<CfgDto>> GetPagedListV2(CfgSearchDto criteria)
        {
            Expression<Func<SysCfg, bool>> condition = it => true;

            if (!string.IsNullOrWhiteSpace(criteria.CfgName))
                condition = condition.And(it => it.CfgName.Contains(criteria.CfgName));

            if (!string.IsNullOrWhiteSpace(criteria.CfgValue))
                condition = condition.And(it => it.CfgValue.Contains(criteria.CfgValue));

            var result = await _unitOfWork.CfgRepository.PagedAsync(
                criteria.Page,
                criteria.Limit,
                condition,
                it => it.Id,
                true);
            var dto = CfgMapper.ToCfgDto(result);

            return dto;
        }
    }
}