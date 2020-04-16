using Doublelives.Api.Infrastructure;
using Doublelives.Api.MockResponse;
using Doublelives.Api.Models.Notice;
using Doublelives.Service.WorkContextAccess;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Doublelives.Api.Controllers
{
    [Route("api/notice")]
    public class NoticeController : AuthControllerBase
    {
        public NoticeController(IWorkContextAccessor workContextAccessor)
            : base(workContextAccessor)
        {
        }

        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var model = MockResponseHelper.GetMockModel<NoticeViewModel>("noticelist");
            await Task.Run(() => { });

            return Ok(model);
        }
    }
}
