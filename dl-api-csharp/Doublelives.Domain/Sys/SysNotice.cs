using Doublelives.Domain.Infrastructure;

namespace Doublelives.Domain.Sys
{
    public class SysNotice : AuditableEntityBase
    {
        public string Content { get; set; }

        public string Title { get; set; }

        public int? Type { get; set; }
    }
}