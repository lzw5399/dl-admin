using Doublelives.Domain.Infrastructure;
using System;

namespace Doublelives.Domain.Sys
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
