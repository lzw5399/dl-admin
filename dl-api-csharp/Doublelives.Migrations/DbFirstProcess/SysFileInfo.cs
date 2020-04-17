using System;
using System.Collections.Generic;

namespace Doublelives.Migrations.DbFirstProcess
{
    public class SysFileInfo : AuditableEntityBase
    {
        public string OriginalFileName { get; set; }

        public string RealFileName { get; set; }
    }
}
