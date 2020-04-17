using System;
using System.Collections.Generic;

namespace Doublelives.Migrations.DbFirstProcess
{
    public class SysTaskLog : EntityBase
    {
        public DateTime? ExecAt { get; set; }

        public int? ExecSuccess { get; set; }

        public int? IdTask { get; set; }

        public string JobException { get; set; }

        public string Name { get; set; }
    }
}
