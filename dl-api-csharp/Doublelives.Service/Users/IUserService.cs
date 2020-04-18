using Doublelives.Domain.Sys;
using Doublelives.Domain.Sys.Dto;
using Doublelives.Domain.Users;
using System.Threading.Tasks;

namespace Doublelives.Service.Users
{
    public interface IUserService
    {
        (bool, string) Login(string username, string pwd);

        string GenerateToken(long id);

        Task<SysUser> GetById(long id);

        void Add(SysUser user);

        void Update(SysUser user);

        void Delete(long id);

        AccountInfoDto GetInfo(long userid);
    }
}
