using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Doublelives.Migrations.DbFirstProcess
{
    public class SysCfg
    {
        public long Id { get; set; }
        public long? CreateBy { get; set; }
        public DateTime? CreateTime { get; set; }
        public long? ModifyBy { get; set; }
        public DateTime? ModifyTime { get; set; }
        public string CfgDesc { get; set; }
        public string CfgName { get; set; }
        public string CfgValue { get; set; }
    }
}
