using Doublelives.Domain.Infrastructure;

namespace Doublelives.Domain.Sys
{
    public class SysRole : AuditableEntityBase
    {
        public long? Deptid { get; set; }

        public string Name { get; set; }

        public long? Num { get; set; }

        public long? Pid { get; set; }

        public string Tips { get; set; }

        public long? Version { get; set; }
    }
}
