using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Doublelives.Persistence;
using Doublelives.Domain.Users;
using Doublelives.Infrastructure.Exceptions;
using Doublelives.Infrastructure.Extensions;
using Doublelives.Shared.ConfigModels;
using IdentityModel;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Doublelives.Service.Users
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtOptions _jwtConfig;
        private readonly IDistributedCache _distributedCache;

        public UserService(
            IUnitOfWork unitOfWork,
            IOptions<JwtOptions> jwtOptions,
            IDistributedCache distributedCache)
        {
            _unitOfWork = unitOfWork;
            _jwtConfig = jwtOptions.Value;
            _distributedCache = distributedCache;
        }

        public string GenerateToken(string id)
        {
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Key);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtClaimTypes.Audience, _jwtConfig.Audience),
                    new Claim(JwtClaimTypes.Issuer, _jwtConfig.Issuer),
                    new Claim(JwtClaimTypes.Subject, id),
                }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtConfig.ExpireMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var securityToken = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);

            var tokenString = tokenHandler.WriteToken(securityToken);

            return tokenString;
        }

        public User GetById(string id)
        {
            var cachedUser = _distributedCache.GetAsObject<User>(id);

            if (cachedUser != null)
            {
                return cachedUser;
            }

            var guid = Guid.Parse(id);

            var dbUser = _unitOfWork.UserRepository.GetAsQueryable().FirstOrDefault(it => it.Id == guid);

            if (dbUser == null)
            {
                throw new NotFoundException("user.NotFound", "user doesn't not found!");
            }

            _distributedCache.SetAsObject(dbUser.Id.ToString(), dbUser);

            return dbUser;
        }

        public void Add(User user)
        {
            _distributedCache.SetAsObject(user.Id.ToString(), user);

            _unitOfWork.UserRepository.Insert(user);
            _unitOfWork.Commit();
        }

        public void Update(User user)
        {
            _distributedCache.SetAsObject(user.Id.ToString(), user);

            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.Commit();
        }

        public void Delete(string id)
        {
            _distributedCache.Remove(id);

            var user = _unitOfWork.UserRepository.GetById(id);
            user.IsDeleted = true;
            _unitOfWork.Commit();
        }
    }
}
