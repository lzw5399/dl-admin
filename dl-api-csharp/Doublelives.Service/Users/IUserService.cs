using Doublelives.Domain.Users;

namespace Doublelives.Service.Users
{
    public interface IUserService
    {
        string GenerateToken(string id);

        User GetById(string id);

        void Add(User user);

        void Update(User user);

        void Delete(string id);
    }
}
