using Doublelives.Domain.Sys;
using Doublelives.Domain.Sys.Dto;
using Doublelives.Domain.Users;
using System.Threading.Tasks;

namespace Doublelives.Service.Users
{
    public interface IUserService
    {
        (bool, string) Login(string username, string pwd);

        string GenerateToken(int id);

        Task<SysUser> GetById(int id);

        void Add(SysUser user);

        void Update(SysUser user);

        void Delete(int id);

        AccountInfoDto GetInfo(int userid);
    }
}
