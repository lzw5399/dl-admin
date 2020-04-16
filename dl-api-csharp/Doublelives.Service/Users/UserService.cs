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
using Doublelives.Infrastructure.Cache;
using Doublelives.Query.Users;
using System.Threading.Tasks;

namespace Doublelives.Service.Users
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtOptions _jwtConfig;
        private readonly IDistributedCache _distributedCache;
        private readonly ICacheManager _cacheManager;
        private readonly IUserQuery _userQuery;
        private const string USER_CACHE_PREFIX = "user";

        public UserService(
            IUnitOfWork unitOfWork,
            IOptions<JwtOptions> jwtOptions,
            IDistributedCache distributedCache,
            ICacheManager cacheManager,
            IUserQuery userQuery)
        {
            _unitOfWork = unitOfWork;
            _jwtConfig = jwtOptions.Value;
            _distributedCache = distributedCache;
            _cacheManager = cacheManager;
            _userQuery = userQuery;
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

        public async Task<User> GetById(string id)
        {
            var cacheKey = $"{USER_CACHE_PREFIX}_id";
            var user = await _cacheManager.GetOrCreateAsync(cacheKey, async entry =>
            {
                return await _userQuery.GetById(id);
            });

            return user;
        }

        public void Add(User user)
        {
            _distributedCache.SetAsObject(user.Id, user);

            _unitOfWork.UserRepository.Insert(user);
            _unitOfWork.Commit();
        }

        public void Update(User user)
        {
            _distributedCache.SetAsObject(user.Id, user);

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
