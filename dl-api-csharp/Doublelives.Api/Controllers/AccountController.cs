using AutoMapper;
using Doublelives.Api.Models.Account;
using Doublelives.Api.Models.Account.Requests;
using Doublelives.Api.Validators.Account;
using Doublelives.Domain.Sys.Dto;
using Doublelives.Infrastructure.Validations;
using Doublelives.Service.Users;
using Doublelives.Service.WorkContextAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Doublelives.Api.Controllers
{
    public class AccountController : AuthControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public AccountController(
            IWorkContextAccessor workContextAccessor,
            IMapper mapper,
            IUserService userService)
            : base(workContextAccessor)
        {
            _mapper = mapper;
            _userService = userService;
        }

        /// <summary>账户登陆</summary>
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(AccountLoginRequest request)
        {
            ModelValidator<AccountLoginRequest, LoginRequestValidator>.Validate(request);

            (var valid, var token) = _userService.Login(request.UserName, request.Password);

            if (!valid) return NotFound("用户名或密码错误，请检查");

            var viewModel = new LoginViewModel(token);

            return Ok(viewModel);
        }

        /// <summary>获取当前账户信息</summary>
        [HttpGet("info")]
        public IActionResult Info()
        {
            // todo kankan cache?
            var result = _userService.GetInfo(WorkContext.CurrentUser.Id);
            var info = _mapper.Map<AccountInfoDto>(result);

            return Ok(info);
        }

        /// <summary>注销</summary>
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            return Ok("注销成功");
        }

        /// <summary>更新密码</summary>
        [HttpPost("updatePwd")]
        public IActionResult UpdatePassword(AccountUpdatePasswordRequest request)
        {
            return Ok();
        }
    }
}