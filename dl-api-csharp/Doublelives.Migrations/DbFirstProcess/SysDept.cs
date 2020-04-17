using System;
using System.Collections.Generic;

namespace Doublelives.Migrations.DbFirstProcess
{
    public class SysDept : AuditableEntityBase
    {
        public string Fullname { get; set; }

        public int? Num { get; set; }

        public long? Pid { get; set; }

        public string Pids { get; set; }

        public string Simplename { get; set; }

        public string Tips { get; set; }

        public int? Version { get; set; }
    }
}
