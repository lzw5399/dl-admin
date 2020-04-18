using Doublelives.Domain.Sys;
using Doublelives.Domain.Sys.Dto;
using Doublelives.Shared.Enum;
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
                    Sex = user.Sex,
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
                    Password = user.Password,
                    Phone = user.Phone,
                    Roleid = user.Roleid,
                    Roles = roles.Select(it => it.Name).ToList(),
                    Salt = user.Salt,
                    Status = user.Status ?? (int)AccountStatus.InActive
                },
                Permissions = permissions
            };

            return dto;
        }
    }
}
