using Doublelives.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Doublelives.Query.Users
{
    public interface IUserQuery
    {
        Task<User> GetById(string id);
    }
}
