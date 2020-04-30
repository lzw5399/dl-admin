using Doublelives.Domain.Sys;
using Doublelives.Domain.Sys.Dto;
using Doublelives.Shared.Models;

namespace Doublelives.Service.Dicts
{
    public interface IDictService
    {
        /// <summary>
        /// 获取分页数据
        /// </summary>
        PagedModel<DictDto> GetPagedList(DictSearchDto criteria);
    }
}