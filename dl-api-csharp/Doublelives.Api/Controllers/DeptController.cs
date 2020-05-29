using AutoMapper;
using Doublelives.Api.Models.Dept;
using Doublelives.Service.Depts;
using Doublelives.Service.WorkContextAccess;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Doublelives.Api.Controllers
{
    public class DeptController : AuthControllerBase
    {
        private readonly IDeptService _deptService;
        private readonly IMapper _mapper;

        public DeptController(
            IWorkContextAccessor workContextAccessor,
            IDeptService deptService,
            IMapper mapper)
            : base(workContextAccessor)
        {
            _deptService = deptService;
            _mapper = mapper;
        }

        /// <summary>获取部门层级</summary>
        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var dtos = await _deptService.List();
            var model = _mapper.Map<List<DeptViewModel>>(dtos);

            return Ok(model);
        }
    }
}