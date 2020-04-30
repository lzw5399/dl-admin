using Doublelives.Domain.Sys;
using Doublelives.Domain.Sys.Dto;
using Doublelives.Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace Doublelives.Service.Mappers
{
    public class DictMapper
    {
        public static PagedModel<DictDto> ToDictProfileDto(
            List<SysDict> all,
            List<SysDict> topDict,
            DictSearchDto criteria)
        {
            var model = new PagedModel<DictDto>
            {
                Ascending = true,
                PageNumber = criteria.Page,
                PageSize = criteria.Limit,
                Sort = "",
                TotalCount = all.Count,
                Data = topDict.Select(it => new DictDto
                {
                    Id = it.Id,
                    ModifyBy = it.ModifyBy,
                    ModifyTime = it.ModifyTime,
                    CreateBy = it.CreateBy,
                    CreateTime = it.CreateTime,
                    Name = it.Name,
                    Num = it.Num,
                    Pid = it.Pid,
                    Tips = it.Tips
                }).ToList()
            };

            return model;
        }
    }
}