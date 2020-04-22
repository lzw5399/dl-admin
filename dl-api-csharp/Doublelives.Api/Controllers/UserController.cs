using System;
using AutoMapper;
using Doublelives.Api.Models.Users;
using Doublelives.Service.Users;
using Doublelives.Service.WorkContextAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Doublelives.Api.Controllers
{
    public class UserController : AuthControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(
            IWorkContextAccessor workContextAccessor,
            IUserService userService,
            IMapper mapper)
            : base(workContextAccessor)
        {
            _userService = userService;
            _mapper = mapper;
        }

        /// <summary>获取token</summary>
        /// <param name="id">若id为空，则使用默认的一个id</param>
        [AllowAnonymous]
        [HttpGet("getToken")]
        public IActionResult GetToken(int id)
        {
            id = id == 0 ? 1 : id;
            var token = _userService.GenerateToken(id);

            return Ok(token);
        }

        /// <summary>使用获得的token</summary>
        [HttpGet("useToken")]
        public IActionResult UseToken()
        {
            var response = _mapper.Map<UserViewModel>(WorkContext.CurrentUser);

            return Ok(response);
        }
    }
}