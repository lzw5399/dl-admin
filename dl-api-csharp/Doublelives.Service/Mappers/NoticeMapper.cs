using Doublelives.Domain.Sys;
using Doublelives.Domain.Sys.Dto;

namespace Doublelives.Service.Mappers
{
    public static class NoticeMapper
    {
        public static NoticeDto ToNoticeDto(SysNotice sysNotice)
        {
            var dto = new NoticeDto
            {
                Content = sysNotice.Content,
                CreateBy = sysNotice.CreateBy,
                CreateTime = sysNotice.CreateTime,
                Id = sysNotice.Id,
                ModifyBy = sysNotice.ModifyBy,
                ModifyTime = sysNotice.ModifyTime,
                Title = sysNotice.Title,
                Type = sysNotice.Type
            };

            return dto;
        }
    }
}