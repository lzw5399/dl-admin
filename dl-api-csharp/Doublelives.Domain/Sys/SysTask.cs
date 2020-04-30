using Doublelives.Domain.Infrastructure;
using System;

namespace Doublelives.Domain.Sys
{
    public class SysTask : AuditableEntityBase
    {
        public bool? Concurrent { get; set; }

        public string Cron { get; set; }

        public string Data { get; set; }

        public bool? Disabled { get; set; }

        public DateTime? ExecAt { get; set; }

        public string ExecResult { get; set; }

        public string JobClass { get; set; }

        public string JobGroup { get; set; }

        public string Name { get; set; }

        public string Note { get; set; }
    }
}