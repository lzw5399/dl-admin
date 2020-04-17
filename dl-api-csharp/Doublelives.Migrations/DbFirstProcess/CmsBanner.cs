using System;
using System.Collections.Generic;

namespace Doublelives.Migrations.DbFirstProcess
{
    public class CmsBanner : AuditableEntityBase
    {
        public int? IdFile { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public string Url { get; set; }
    }
}
