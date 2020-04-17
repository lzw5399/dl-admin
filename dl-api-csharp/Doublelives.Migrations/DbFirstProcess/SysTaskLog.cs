using System;
using System.Collections.Generic;

namespace Doublelives.Migrations.DbFirstProcess
{
    public partial class SysTaskLog
    {
        public long Id { get; set; }
        public DateTime? ExecAt { get; set; }
        public int? ExecSuccess { get; set; }
        public long? IdTask { get; set; }
        public string JobException { get; set; }
        public string Name { get; set; }
    }
}
