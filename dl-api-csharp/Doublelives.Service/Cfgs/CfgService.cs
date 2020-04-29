using Doublelives.Domain.Sys;
using Doublelives.Domain.Sys.Dto;
using Doublelives.Infrastructure.Cache;
using Doublelives.Infrastructure.Extensions;
using Doublelives.Persistence;
using Doublelives.Service.Mappers;
using Doublelives.Shared.Models;
using System;
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
            Expression<Func<SysCfg, bool>> condition = it => true;

            if (!string.IsNullOrWhiteSpace(criteria.CfgName))
            {
                condition = condition.And(it => it.CfgName.Contains(criteria.CfgName));
            }

            if (!string.IsNullOrWhiteSpace(criteria.CfgValue))
            {
                condition = condition.And(it => it.CfgValue.Contains(criteria.CfgValue));
            }

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
