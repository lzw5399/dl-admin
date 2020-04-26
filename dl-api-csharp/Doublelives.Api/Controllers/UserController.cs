using AutoMapper;
using Doublelives.Api.Mappers;
using Doublelives.Api.Models.Account;
using Doublelives.Api.Models.Users;
using Doublelives.Api.Models.Users.Requests;
using Doublelives.Service.Users;
using Doublelives.Service.WorkContextAccess;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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
        public IActionResult List([FromQuery]UserListSearchRequest request)
        {
            var result = _userService.GetPagedList(UserMapper.ToUserSearchDto(request));

            var viewModel = new UserPagedListViewModel
            {
                Current = result.PageNumber,
                Pages = result.PageCount,
                Size = result.PageSize,
                Sort = result.Sort,
                Total = result.TotalCount,
                Records = _mapper.Map<List<AccountProfileViewModel>>(result.Data)
            };

            return Ok(viewModel);
        }
    }
}