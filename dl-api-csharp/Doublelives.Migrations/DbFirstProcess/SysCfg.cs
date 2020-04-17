using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Doublelives.Migrations.DbFirstProcess
{
    public class SysCfg : AuditableEntityBase
    {
        public string CfgDesc { get; set; }

        public string CfgName { get; set; }

        public string CfgValue { get; set; }
    }
}
