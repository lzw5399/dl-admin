using Doublelives.Domain.Sys;
using Doublelives.Domain.Sys.Dto;
using Doublelives.Shared.Models;
using System.Linq;

namespace Doublelives.Service.Mappers
{
    public class RoleMapper
    {
        public static PagedModel<RoleProfileDto> ToRoleProfileDto(PagedModel<SysRole> pagedModel)
        {
            var model = new PagedModel<RoleProfileDto>
            {
                Ascending = pagedModel.Ascending,
                PageNumber = pagedModel.PageNumber,
                PageSize = pagedModel.PageSize,
                Sort = pagedModel.Sort,
                TotalCount = pagedModel.TotalCount,
                Data = pagedModel.Data.Select(it => new RoleProfileDto
                {
                    Id = it.Id,
                    ModifyBy = it.ModifyBy,
                    ModifyTime = it.ModifyTime,
                    CreateBy = it.CreateBy,
                    CreateTime = it.CreateTime,
                    Deptid = it.Deptid,
                    Name = it.Name,
                    Num = it.Num,
                    Pid = it.Pid,
                    Tips = it.Tips,
                    Version = it.Version
                }).ToList()
            };

            return model;
        }
    }
}
