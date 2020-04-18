using Doublelives.Domain.Infrastructure;

namespace Doublelives.Domain.Sys
{
    public class SysDept : AuditableEntityBase
    {
        public string Fullname { get; set; }

        public long? Num { get; set; }

        public long? Pid { get; set; }

        public string Pids { get; set; }

        public string Simplename { get; set; }

        public string Tips { get; set; }

        public long? Version { get; set; }
    }
}
