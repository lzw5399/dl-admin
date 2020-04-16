using Doublelives.Domain.Users;
using Doublelives.Infrastructure.Cache;
using Doublelives.Infrastructure.Exceptions;
using Doublelives.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doublelives.Query.Users
{
    public class UserQuery : IUserQuery
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> GetById(string id)
        {
            var guid = Guid.Parse(id);
            var user = await _unitOfWork.UserRepository.GetAsQueryable().FirstOrDefaultAsync(it => it.Id == guid);

            if (user == null)
            {
                throw new NotFoundException("user.NotFound", "user doesn't not found!");
            }

            return user;
        }
    }
}
