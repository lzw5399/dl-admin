using System;
using System.Collections.Generic;

namespace Doublelives.Migrations.DbFirstProcess
{
    public partial class SysRole
    {
        public long Id { get; set; }
        public long? CreateBy { get; set; }
        public DateTime? CreateTime { get; set; }
        public long? ModifyBy { get; set; }
        public DateTime? ModifyTime { get; set; }
        public long? Deptid { get; set; }
        public string Name { get; set; }
        public int? Num { get; set; }
        public long? Pid { get; set; }
        public string Tips { get; set; }
        public int? Version { get; set; }
    }
}
