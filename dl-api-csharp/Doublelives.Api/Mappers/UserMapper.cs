using Doublelives.Api.Models.Users.Requests;
using Doublelives.Domain.Sys.Dto;
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
    }
}
