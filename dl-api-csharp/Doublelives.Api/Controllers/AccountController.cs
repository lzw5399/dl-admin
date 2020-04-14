using AutoMapper;
using Doublelives.Api.Infrastructure;
using Doublelives.Api.Models.Account;
using Doublelives.Service.Users;
using Doublelives.Service.WorkContextAccess;
using Microsoft.AspNetCore.Mvc;

namespace Doublelives.Api.Controllers
{
    [Route("api/account")]
    public class AccountController : AuthControllerBase
    {
        private readonly IMapper _mapper;
        
        public AccountController(
            IWorkContextAccessor workContextAccessor,
            IMapper mapper)
            : base(workContextAccessor)
        {
            _mapper = mapper;
        }

        [HttpGet("info")]
        public IActionResult Info()
        {
            if (WorkContext.CurrentUser == null) return Unauthorized();
            
            var response = _mapper.Map<AccountViewModel>(WorkContext.CurrentUser);

            return Ok(response);
        }
    }
}