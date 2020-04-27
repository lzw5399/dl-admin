using Doublelives.Domain.Sys.Dto;
using System.Collections.Generic;

namespace Doublelives.Service.Notices
{
    public interface INoticeService
    {
        List<NoticeDto> List(string title);
    }
}
