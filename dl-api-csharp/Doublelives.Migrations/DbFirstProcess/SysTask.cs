using System;
using System.Collections.Generic;

namespace Doublelives.Migrations.DbFirstProcess
{
    public partial class SysTask
    {
        public long Id { get; set; }
        public long? CreateBy { get; set; }
        public DateTime? CreateTime { get; set; }
        public long? ModifyBy { get; set; }
        public DateTime? ModifyTime { get; set; }
        public sbyte? Concurrent { get; set; }
        public string Cron { get; set; }
        public string Data { get; set; }
        public sbyte? Disabled { get; set; }
        public DateTime? ExecAt { get; set; }
        public string ExecResult { get; set; }
        public string JobClass { get; set; }
        public string JobGroup { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
    }
}
