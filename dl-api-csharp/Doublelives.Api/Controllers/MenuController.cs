using Doublelives.Api.Infrastructure;
using Doublelives.Api.MockResponse;
using Doublelives.Api.Models.Menu;
using Doublelives.Service.WorkContextAccess;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doublelives.Api.Controllers
{
    [Route("api/menu")]
    public class MenuController : AuthControllerBase
    {
        public MenuController(IWorkContextAccessor workContextAccessor)
            : base(workContextAccessor)
        {

        }

        [HttpGet("listForRouter")]
        public async Task<IActionResult> ListForRouter()
        {
            var model = MockResponseHelper.GetMockModel<List<ListFouRouterViewModel>>("listForRouter");
            await Task.Run(() => { });

            return Ok(model);
        }
    }
}
