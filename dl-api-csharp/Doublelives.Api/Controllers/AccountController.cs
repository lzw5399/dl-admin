using AutoMapper;
using Doublelives.Api.Infrastructure;
using Doublelives.Api.MockResponse;
using Doublelives.Api.Models.Account;
using Doublelives.Api.Models.Account.Requests;
using Doublelives.Api.Validators.Account;
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

            if (!valid) return NotFound();

            var viewModel = new LoginViewModel(token);

            return Ok(viewModel);
        }

        /// <summary>获取当前账户信息</summary>
        [HttpGet("info")]
        public IActionResult Info()
        {
            //if (WorkContext.CurrentUser == null) return Unauthorized();
            //var response = _mapper.Map<AccountViewModel>(WorkContext.CurrentUser);
            //return Ok(response);
            var model = MockResponseHelper.GetMockModel<AccountData>("info");
            return Ok(model);
        }

        /// <summary>更新密码</summary>
        [AllowAnonymous]
        [HttpPost("updatePwd")]
        public IActionResult UpdatePassword(AccountUpdatePasswordRequest request)
        {
            return Ok();
            // var token = _userService.GenerateToken(request);
            //
            // return Ok(token);
        }
    }
}