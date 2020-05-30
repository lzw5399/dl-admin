using AutoMapper;
using Doublelives.Api.Models.Notice;
using Doublelives.Service.Notices;
using Doublelives.Service.WorkContextAccess;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doublelives.Api.Controllers
{
    public class NoticeController : AuthControllerBase
    {
        private readonly INoticeService _noticeService;
        private readonly IMapper _mapper;

        public NoticeController(
            IWorkContextAccessor workContextAccessor,
            INoticeService noticeService,
            IMapper mapper)
            : base(workContextAccessor)
        {
            _noticeService = noticeService;
            _mapper = mapper;
        }

        [HttpGet("list")]
        public async Task<IActionResult> List(string title)
        {
            var result = await _noticeService.List(title);
            var list = _mapper.Map<List<NoticeViewModel>>(result);

            return Ok(list);
        }
    }
}