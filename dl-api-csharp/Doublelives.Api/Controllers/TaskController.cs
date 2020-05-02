using Doublelives.Service.Tasks;
using Doublelives.Service.WorkContextAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Doublelives.Api.Controllers
{
    public class TaskController : AuthControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(
            IWorkContextAccessor workContextAccessor,
            ITaskService taskService)
            : base(workContextAccessor)
        {
            _taskService = taskService;
        }

        [AllowAnonymous]
        [HttpGet("warmup")]
        public IActionResult WarmupDatabase()
        {
            _taskService.ImportDataFromJsonFile();
            //_taskService.WarmupDatabase();
            return Ok("1");
        }

        [AllowAnonymous]
        [HttpGet("flushallCache")]
        public IActionResult FlushallCache()
        {
            _taskService.FlushallCache();

            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("cachefiller")]
        public IActionResult CacheFiller()
        {
            _taskService.FillCache();

            return Ok();
        }
    }
}