using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Doublelives.Persistence;
using Doublelives.Shared.ConfigModels;
using IdentityModel;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Doublelives.Infrastructure.Cache;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Doublelives.Infrastructure.Helpers;
using Doublelives.Domain.Sys;
using Doublelives.Domain.Sys.Dto;
using Doublelives.Infrastructure.Exceptions;
using System.Collections.Generic;
using Doublelives.Service.Mappers;

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

        public (bool, string) Login(string account, string pwd)
        {
            var user = GetByAccountName(account);

            if (user == null) return (false, null);

            if (HashHelper.GetHashedString(HashType.MD5, pwd, Encoding.UTF8) != user.Password) return (false, null);

            var token = GenerateToken(user.Id);

            return (true, token);
        }

        public string GenerateToken(long id)
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

        public AccountInfoDto GetInfo(long userid)
        {
            var user = GetById(userid).Result;
            if (user == null) throw new NotFoundException("code", "用户无法找到，请重新登录!");

            var roles = new List<SysRole>();
            var permissions = new List<string>();
            if (!string.IsNullOrEmpty(user.Roleid))
            {
                var ids = user.Roleid.Split(',').Select(id => int.Parse(id)).ToList();
                foreach (var id in ids)
                {
                    var role = _unitOfWork.RoleRepository.GetById(id);
                    if (role == null) continue;

                    roles.Add(role);
                }
                permissions = _unitOfWork.MenuRepository.GetPermissionsByRoleIds(ids);
            }

            var dept = _unitOfWork.DeptRepository.GetById(user.Deptid);

            return UserMapper.ToAccountInfoDto(user, dept, roles, permissions);
        }

        public async Task<SysUser> GetById(long id)
        {
            var cacheKey = $"{USER_CACHE_PREFIX}_{id}";
            var user = await _cacheManager.GetOrCreateAsync(cacheKey, async entry => await GetByIdFromDb(id));

            return user;
        }

        public SysUser GetByAccountName(string account)
        {
            var user = _unitOfWork.UserRepository.GetAsQueryable().FirstOrDefault(it => it.Account == account);

            return user;
        }

        public void Add(SysUser user)
        {
            _unitOfWork.UserRepository.Insert(user);
            _unitOfWork.Commit();

            _cacheManager.Remove($"{USER_CACHE_PREFIX}_{user.Id}");
        }

        public void Update(SysUser user)
        {
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.Commit();

            _cacheManager.Remove($"{USER_CACHE_PREFIX}_{user.Id}");
        }

        public void Delete(long id)
        {
            _unitOfWork.UserRepository.DeleteById(id);
            _unitOfWork.Commit();

            _cacheManager.Remove($"{USER_CACHE_PREFIX}_{id}");
        }

        private async Task<SysUser> GetByIdFromDb(long id)
        {
            var user = await _unitOfWork.UserRepository.GetAsQueryable().FirstOrDefaultAsync(it => it.Id == id);

            return user;
        }
    }
}
