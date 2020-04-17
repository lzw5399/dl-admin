using System;
using System.Collections.Generic;

namespace Doublelives.Migrations.DbFirstProcess
{
    public class SysNotice : AuditableEntityBase
    {
        public string Content { get; set; }

        public string Title { get; set; }

        public int? Type { get; set; }
    }
}
