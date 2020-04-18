using Doublelives.Api.Infrastructure;
using Doublelives.Api.MockResponse;
using Doublelives.Api.Models.Menu;
using Doublelives.Service.WorkContextAccess;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Doublelives.Api.Controllers
{
    public class MenuController : AuthControllerBase
    {
        public MenuController(IWorkContextAccessor workContextAccessor)
            : base(workContextAccessor)
        {

        }

        [HttpGet("listForRouter")]
        public IActionResult ListForRouter()
        {
            var model = MockResponseHelper.GetMockModel<List<ListFouRouterViewModel>>("listForRouter");

            return Ok(model);
        }
    }
}
