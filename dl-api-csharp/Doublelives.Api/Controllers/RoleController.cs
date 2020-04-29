using Doublelives.Api.Mappers;
using Doublelives.Api.Models.Roles.Requests;
using Doublelives.Service.Roles;
using Doublelives.Service.WorkContextAccess;
using Microsoft.AspNetCore.Mvc;

namespace Doublelives.Api.Controllers
{
    public class RoleController : AuthControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(
            IWorkContextAccessor workContextAccessor,
            IRoleService roleService)
            : base(workContextAccessor)
        {
            _roleService = roleService;
        }

        /// <summary>
        /// 获取角色分页列表
        /// </summary>
        [HttpGet("list")]
        public IActionResult List([FromQuery]RoleListSearchRequest request)
        {
            var result = _roleService.GetPagedList(RoleMapper.ToRoleSearchDto(request));
            var viewModels = RoleMapper.ToPagedListViewModel(result);

            return Ok(viewModels);
        }
    }
}
