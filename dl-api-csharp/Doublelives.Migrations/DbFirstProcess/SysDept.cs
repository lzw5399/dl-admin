using System;
using System.Collections.Generic;

namespace Doublelives.Migrations.DbFirstProcess
{
    public partial class SysDept
    {
        public long Id { get; set; }
        public long? CreateBy { get; set; }
        public DateTime? CreateTime { get; set; }
        public long? ModifyBy { get; set; }
        public DateTime? ModifyTime { get; set; }
        public string Fullname { get; set; }
        public int? Num { get; set; }
        public long? Pid { get; set; }
        public string Pids { get; set; }
        public string Simplename { get; set; }
        public string Tips { get; set; }
        public int? Version { get; set; }
    }
}
