using Doublelives.Domain.Infrastructure;

namespace Doublelives.Domain.Sys
{
    public class SysFileInfo : AuditableEntityBase
    {
        public string OriginalFileName { get; set; }

        public string RealFileName { get; set; }
    }
}