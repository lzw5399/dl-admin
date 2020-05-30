using Doublelives.Domain.Sys.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doublelives.Service.Notices
{
    public interface INoticeService
    {
        Task<List<NoticeDto>> List(string title);
    }
}