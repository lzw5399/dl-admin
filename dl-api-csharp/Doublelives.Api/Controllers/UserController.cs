using AutoMapper;
using Doublelives.Service.Users;
using Doublelives.Service.WorkContextAccess;
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

        [HttpGet("list")]
        public IActionResult List()
        {
            return Ok();
        }
    }
}