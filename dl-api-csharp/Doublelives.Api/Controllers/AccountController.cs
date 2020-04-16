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
using System.Threading.Tasks;

namespace Doublelives.Api.Controllers
{
    [Route("api/account")]
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
        public async Task<IActionResult> Login(AccountLoginRequest request)
        {
            ModelValidator<AccountLoginRequest, LoginRequestValidator>.Validate(request);

            var token = _userService.GenerateToken("2069b03a-9167-455c-9db8-5846334e5f20");

            var viewModel = new LoginViewModel(token);

            await Task.Run(() => { });
            return Ok(viewModel);
        }

        /// <summary>获取当前账户信息</summary>
        [HttpGet("info")]
        public async Task<IActionResult> Info()
        {
            //if (WorkContext.CurrentUser == null) return Unauthorized();
            //var response = _mapper.Map<AccountViewModel>(WorkContext.CurrentUser);
            //return Ok(response);
            var model = MockResponseHelper.GetMockModel<AccountData>("info");
            await Task.Run(() => { });
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