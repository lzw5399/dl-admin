using AutoMapper;
using Doublelives.Api.Mappers;
using Doublelives.Api.Models.Dicts;
using Doublelives.Api.Models.Dicts.Requests;
using Doublelives.Service.Dicts;
using Doublelives.Service.WorkContextAccess;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Doublelives.Api.Controllers
{
    public class DictController : AuthControllerBase
    {
        private readonly IDictService _dictService;
        private readonly IMapper _mapper;

        public DictController(
            IWorkContextAccessor workContextAccessor,
            IDictService dictService,
            IMapper mapper)
            : base(workContextAccessor)
        {
            _dictService = dictService;
            _mapper = mapper;
        }

        /// <summary>
        /// 获取分页的dict
        /// </summary>
        [HttpGet("list")]
        public IActionResult List([FromQuery] DictListSearchRequest request)
        {
            var result = _dictService.GetPagedList(DictMapper.ToDictSearchDto(request));
            var viewModels = _mapper.Map<List<DictViewModel>>(result.Data);

            return Ok(viewModels);
        }
    }
}