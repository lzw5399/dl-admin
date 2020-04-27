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
using Doublelives.Infrastructure.Extensions;
using Doublelives.Shared.Constants;
using System.Linq.Expressions;
using Doublelives.Shared.Enum;
using Doublelives.Shared.Models;
using Doublelives.Service.Depts;
using Doublelives.Service.Roles;

namespace Doublelives.Service.Users
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtOptions _jwtConfig;
        private readonly ICacheManager _cacheManager;
        private readonly IDeptService _deptService;
        private readonly IRoleService _roleService;

        public UserService(
            IUnitOfWork unitOfWork,
            IOptions<JwtOptions> jwtOptions,
            ICacheManager cacheManager,
            IDeptService deptService,
            IRoleService roleService)
        {
            _unitOfWork = unitOfWork;
            _jwtConfig = jwtOptions.Value;
            _cacheManager = cacheManager;
            _deptService = deptService;
            _roleService = roleService;
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
            if (user == null) throw new UserNotFoundException();

            var roles = new List<SysRole>();
            var permissions = new List<string>();
            if (!string.IsNullOrEmpty(user.Roleid))
            {
                var ids = SplitId(user.Roleid);
                foreach (var id in ids)
                {
                    var role = _roleService.GetById(id);
                    if (role == null) continue;

                    roles.Add(role);
                }
                permissions = _unitOfWork.MenuRepository.GetPermissionsByRoleIds(ids);
            }

            var dept = _deptService.GetById(user.Deptid.Value());

            return UserMapper.ToAccountInfoDto(user, dept, roles, permissions);
        }

        public PagedModel<AccountProfileDto> GetPagedList(UserSearchDto criteria)
        {
            Expression<Func<SysUser, bool>> condition = it => it.Status == AccountStatus.Active;

            if (!string.IsNullOrWhiteSpace(criteria.Account))
            {
                condition = condition.And(it => it.Account.Contains(criteria.Account));
            }

            if (!string.IsNullOrWhiteSpace(criteria.Name))
            {
                condition = condition.And(it => it.Name.Contains(criteria.Name));
            }

            var result = _unitOfWork.UserRepository.Paged(
                criteria.Page,
                criteria.Limit,
                condition,
                it => it.Id,
                true);

            var dto = UserMapper.ToAccountProfileDto(result);

            if (dto.Count <= 0) return dto;

            foreach (var item in dto.Data)
            {
                var dept = _deptService.GetById(item.Deptid);
                var roleIds = SplitId(item.Roleid);
                var roles = _roleService.GetListByIds(roleIds);

                // mapping
                item.Dept = dept?.Fullname;
                item.DeptName = dept?.Simplename;
                item.RoleName = string.Join(',', roles.Select(it => it.Name));
            }

            return dto;
        }

        public async Task<SysUser> GetById(long id)
        {
            var cacheKey = GetUserCacheKey(id);
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

            _cacheManager.Remove(GetUserCacheKey(user.Id));
        }

        public void Update(UserUpdateDto request)
        {
            var user = GetById(request.Id).Result;
            if (user == null) throw new NotFoundException();

            user.Account = request.Account;
            user.Sex = request.Sex;
            user.Phone = request.Phone;
            user.Name = request.Name;
            user.Email = request.Email;
            user.Deptid = request.Deptid;
            user.Birthday = request.Birthday;
            user.Status = request.Status;
            user.Version = user.Version + 1 ?? 1;
            user.ModifyBy = request.ModifyBy;
            user.ModifyTime = DateTime.Now;
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.Commit();

            _cacheManager.Remove(GetUserCacheKey(user.Id));
        }

        public void Delete(long id)
        {
            _unitOfWork.UserRepository.DeleteById(id);
            _unitOfWork.Commit();

            _cacheManager.Remove(GetUserCacheKey(id));
        }

        private async Task<SysUser> GetByIdFromDb(long id)
        {
            var user = await _unitOfWork.UserRepository.GetAsQueryable().FirstOrDefaultAsync(it => it.Id == id);

            return user;
        }

        private List<int> SplitId(string ids)
        {
            return ids.TrimEnd(',').Split(',').Select(id => int.Parse(id)).ToList();
        }

        private string GetUserCacheKey(long id) => CacheHelper.ToCacheKey(CacheKeyPrefix.USER_CACHE_PREFIX, id);
    }
}
