﻿using Doublelives.Domain.Infrastructure;

namespace Doublelives.Domain.Sys
{
    public class SysDict : AuditableEntityBase
    {
        public string Name { get; set; }

        public string Num { get; set; }

        public int? Pid { get; set; }

        public string Tips { get; set; }
    }
}