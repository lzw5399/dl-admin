using Doublelives.Api.Mappers;
using Doublelives.Api.Models.Dicts.Requests;
using Doublelives.Service.Dicts;
using Doublelives.Service.WorkContextAccess;
using Microsoft.AspNetCore.Mvc;

namespace Doublelives.Api.Controllers
{
    public class DictController : AuthControllerBase
    {
        private readonly IDictService _dictService;

        public DictController(
            IWorkContextAccessor workContextAccessor,
            IDictService dictService)
            : base(workContextAccessor)
        {
            _dictService = dictService;
        }

        [HttpGet("list")]
        public IActionResult List([FromQuery]DictListSearchRequest request)
        {
            var result = _dictService.GetPagedList(DictMapper.ToDictSearchDto(request));

            return Ok("");
        }
    }
}
