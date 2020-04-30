using Doublelives.Api.Models.Users.Requests;
using Doublelives.Domain.Sys.Dto;
using Doublelives.Domain.Users.Dto;
using Doublelives.Shared.Enum;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doublelives.Api.Mappers
{
    /// <summary>
    /// 从request model 到 dto的mapping
    /// </summary>
    public static class UserMapper
    {
        public static UserSearchDto ToUserSearchDto(UserListSearchRequest request)
        {
            var dto = new UserSearchDto
            {
                Account = request.Account?.Trim(),
                Name = request.Name?.Trim(),
                Limit = request.Limit,
                Page = request.Page
            };

            return dto;
        }

        public static UserUpdateDto ToUserUpdateDto(UserUpdateRequest request, CurrentUserDto currentUser)
        {
            var dto = new UserUpdateDto
            {
                Id = request.Id,
                Account = request.Account.Trim(),
                Name = request.Name.Trim(),
                Deptid = request.Deptid,
                Birthday = request.Birthday,
                Email = request.Email,
                Phone = request.Phone,
                Sex = request.Sex,
                Status = request.Status ? AccountStatus.Active : AccountStatus.InActive,
                ModifyBy = currentUser.Id
            };

            return dto;
        }
    }
}