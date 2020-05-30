using AutoMapper;
using Doublelives.Api.Models.Menu;
using Doublelives.Service.Menus;
using Doublelives.Service.WorkContextAccess;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doublelives.Api.Controllers
{
    public class MenuController : AuthControllerBase
    {
        private readonly IMenuService _menuService;
        private readonly IMapper _mapper;

        public MenuController(
            IWorkContextAccessor workContextAccessor,
            IMenuService menuService,
            IMapper mapper)
            : base(workContextAccessor)
        {
            _menuService = menuService;
            _mapper = mapper;
        }

        /// <summary>获取侧边路由</summary>
        [HttpGet("listForRouter")]
        public async Task<IActionResult> ListForRouter()
        {
            var list = await _menuService.GetMenuRouterList(WorkContext.CurrentUser.Id);
            var routers = _mapper.Map<List<RouterViewModel>>(list);

            return Ok(routers);
        }
    }
}