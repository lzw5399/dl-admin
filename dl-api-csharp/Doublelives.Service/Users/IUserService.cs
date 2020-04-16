using Doublelives.Domain.Users;
using System.Threading.Tasks;

namespace Doublelives.Service.Users
{
    public interface IUserService
    {
        string GenerateToken(string id);

        Task<User> GetById(string id);

        void Add(User user);

        void Update(User user);

        void Delete(string id);
    }
}
