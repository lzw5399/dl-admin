using Doublelives.Domain.Sys;
using Doublelives.Domain.Sys.Dto;
using Doublelives.Shared.Models;
using System.Threading.Tasks;

namespace Doublelives.Service.Users
{
    public interface IUserService
    {
        Task<(bool, string)> Login(string username, string pwd);

        string GenerateToken(long id);

        Task<SysUser> GetById(long id);

        Task Add(SysUser user);

        Task Update(UserUpdateDto dto);

        Task Delete(long id);

        Task<AccountInfoDto> GetInfo(long userid);

        Task<PagedModel<AccountProfileDto>> GetPagedList(UserSearchDto userSearchDto);
    }
}