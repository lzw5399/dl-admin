using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Doublelives.Persistence;
using Doublelives.Domain.Users;
using Doublelives.Shared.ConfigModels;
using IdentityModel;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Doublelives.Infrastructure.Cache;
using System.Threading.Tasks;
using Doublelives.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Doublelives.Infrastructure.Helpers;

namespace Doublelives.Service.Users
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtOptions _jwtConfig;
        private readonly ICacheManager _cacheManager;
        private const string USER_CACHE_PREFIX = "user";

        public UserService(
            IUnitOfWork unitOfWork,
            IOptions<JwtOptions> jwtOptions,
            ICacheManager cacheManager)
        {
            _unitOfWork = unitOfWork;
            _jwtConfig = jwtOptions.Value;
            _cacheManager = cacheManager;
        }

        public (bool, string) Login(string username, string pwd)
        {
            var user = _unitOfWork.UserRepository.GetAsQueryable().FirstOrDefault(it => it.Name == username);

            if (user == null) return (false, null);

            if (HashHelper.GetHashedString(HashType.MD5, pwd, Encoding.UTF8) != user.Password) return (false, null);

            var token = GenerateToken(user.Id);

            return (true, token);
        }

        public string GenerateToken(int id)
        {
            var key = Encoding.UTF8.GetBytes(_jwtConfig.Key);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtClaimTypes.Audience, _jwtConfig.Audience),
                    new Claim(JwtClaimTypes.Issuer, _jwtConfig.Issuer),
                    new Claim(JwtClaimTypes.Subject, id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtConfig.ExpireMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var securityToken = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);

            var tokenString = tokenHandler.WriteToken(securityToken);

            return tokenString;
        }

        public async Task<User> GetById(int id)
        {
            var cacheKey = $"{USER_CACHE_PREFIX}_{id}";
            var user = await _cacheManager.GetOrCreateAsync(cacheKey, async entry =>
            {
                return await GetByIdFromDb(id);
            });

            return user;
        }

        public void Add(User user)
        {
            _unitOfWork.UserRepository.Insert(user);
            _unitOfWork.Commit();

            _cacheManager.Remove($"{USER_CACHE_PREFIX}_{user.Id}");
        }

        public void Update(User user)
        {
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.Commit();

            _cacheManager.Remove($"{USER_CACHE_PREFIX}_{user.Id}");
        }

        public void Delete(string id)
        {
            var user = _unitOfWork.UserRepository.GetById(id);
            user.IsDeleted = true;
            _unitOfWork.Commit();

            _cacheManager.Remove($"{USER_CACHE_PREFIX}_{user.Id}");
        }

        private async Task<User> GetByIdFromDb(int id)
        {
            var user = await _unitOfWork.UserRepository.GetAsQueryable().FirstOrDefaultAsync(it => it.Id == id);

            if (user == null)
            {
                throw new NotFoundException("user.NotFound", "user doesn't not found!");
            }

            return user;
        }


    }
}
