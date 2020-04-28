using Doublelives.Domain.Sys;
using Doublelives.Domain.Sys.Dto;
using Doublelives.Infrastructure.Extensions;
using Doublelives.Shared.Enum;
using Doublelives.Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace Doublelives.Service.Mappers
{
    public static class UserMapper
    {
        public static AccountInfoDto ToAccountInfoDto(
            SysUser user,
            SysDept dept,
            List<SysRole> roles,
            List<string> permissions)
        {
            var dto = new AccountInfoDto
            {
                Name = user.Name,
                Role = user.Account, // todo??
                Roles = roles.Select(it => it.Tips).ToList(),
                Profile = new AccountProfileDto
                {
                    Dept = dept.Fullname,
                    Deptid = dept.Id,
                    Account = user.Account,
                    Sex = (int)user.Sex,
                    Avatar = user.Avatar,
                    Birthday = user.Birthday,
                    Version = user.Version,
                    CreateBy = user.CreateBy,
                    CreateTime = user.CreateTime,
                    Email = user.Email,
                    Id = user.Id,
                    ModifyBy = user.ModifyBy,
                    ModifyTime = user.ModifyTime,
                    Name = user.Name,
                    Phone = user.Phone,
                    Roleid = user.Roleid,
                    Roles = roles.Select(it => it.Name).ToList(),
                    Status = user.Status == AccountStatus.Active,
                    DeptName = dept.Simplename,
                    RoleName = string.Join(',', roles.Select(it => it.Name)),
                },
                Permissions = permissions
            };

            return dto;
        }

        public static PagedModel<AccountProfileDto> ToAccountProfileDto(PagedModel<SysUser> pagedModel)
        {
            var model = new PagedModel<AccountProfileDto>
            {
                Ascending = pagedModel.Ascending,
                PageNumber = pagedModel.PageNumber,
                PageSize = pagedModel.PageSize,
                Sort = pagedModel.Sort,
                TotalCount = pagedModel.TotalCount,
                Data = pagedModel.Data.Select(it => new AccountProfileDto
                {
                    Id = it.Id,
                    Account = it.Account,
                    Avatar = it.Avatar,
                    Birthday = it.Birthday,
                    Email = it.Email,
                    Name = it.Name,
                    Phone = it.Phone,
                    ModifyBy = it.ModifyBy,
                    ModifyTime = it.ModifyTime,
                    CreateBy = it.CreateBy,
                    CreateTime = it.CreateTime,
                    Sex = (int)it.Sex,
                    Version = it.Version,
                    Status = it.Status == AccountStatus.Active,
                    Deptid = it.Deptid.Value(),
                    Roleid = it.Roleid
                }).ToList()
            };
            return model;
        }
    }
}
