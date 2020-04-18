using Doublelives.Domain.Users;
using System.Threading.Tasks;

namespace Doublelives.Service.Users
{
    public interface IUserService
    {
        (bool, string) Login(string username, string pwd);

        string GenerateToken(int id);

        Task<User> GetById(int id);

        void Add(User user);

        void Update(User user);

        void Delete(string id);
    }
}
