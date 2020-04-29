using Doublelives.Api.Mappers;
using Doublelives.Api.Models.Cfgs.Requests;
using Doublelives.Service.Cfgs;
using Doublelives.Service.WorkContextAccess;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Doublelives.Api.Controllers
{
    public class CfgController : AuthControllerBase
    {
        private readonly ICfgService _cfgService;

        public CfgController(
            IWorkContextAccessor workContextAccessor,
            ICfgService cfgService)
            : base(workContextAccessor)
        {
            _cfgService = cfgService;
        }

        /// <summary>
        /// 获取分页的cfg
        /// </summary>
        [HttpGet("list")]
        public async Task<IActionResult> List([FromQuery]CfgListSearchRequest request)
        {
            var result = await _cfgService.GetPagedList(CfgMapper.ToCfgSearchDto(request));

            return Ok("1");
        }
    }
}
