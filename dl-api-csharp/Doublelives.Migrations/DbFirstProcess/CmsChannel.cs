using System;
using System.Collections.Generic;

namespace Doublelives.Migrations.DbFirstProcess
{
    public class CmsChannel : AuditableEntityBase
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}
