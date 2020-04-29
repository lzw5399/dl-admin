using Doublelives.Api.Models.Roles;
using Doublelives.Api.Models.Roles.Requests;
using Doublelives.Domain.Sys.Dto;
using Doublelives.Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace Doublelives.Api.Mappers
{
    public class RoleMapper
    {
        public static RoleSearchDto ToRoleSearchDto(RoleListSearchRequest request)
        {
            var dto = new RoleSearchDto
            {
                Limit = request.Limit == 0 ? 10 : request.Limit,
                Page = request.Page == 0 ? 1 : request.Page,
                RoleName = request.Name
            };

            return dto;
        }

        public static List<RoleViewModel> ToPagedListViewModel(PagedModel<RoleProfileDto> result)
        {
            var viewModels = result.Data.Select(it =>
            {
                var model = new RoleViewModel
                {
                    Deptid = it.Deptid?.ToString(),
                    CreateBy = it.CreateBy,
                    CreateTime = it.CreateTime,
                    Id = it.Id.ToString(),
                    ModifyBy = it.ModifyBy,
                    ModifyTime = it.ModifyTime,
                    Name = it.Name,
                    Num = it.Num ?? 1,
                    Pid = it.Pid?.ToString(),
                    Tips = it.Tips,
                    Version = it.Version ?? 1,
                    DeptName = it.DeptName,
                    PName = it.PName
                };

                return model;
            }).ToList();

            return viewModels;
        }
    }
}
