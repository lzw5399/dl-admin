using System;
using System.Collections.Generic;

namespace Doublelives.Migrations.DbFirstProcess
{
    public class SysDict : AuditableEntityBase
    {
        public string Name { get; set; }

        public string Num { get; set; }

        public int? Pid { get; set; }

        public string Tips { get; set; }
    }
}
