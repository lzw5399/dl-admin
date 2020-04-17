using System;
using System.Collections.Generic;

namespace Doublelives.Migrations.DbFirstProcess
{
    public partial class SysOperationLog
    {
        public long Id { get; set; }
        public string Classname { get; set; }
        public DateTime? CreateTime { get; set; }
        public string Logname { get; set; }
        public string Logtype { get; set; }
        public string Message { get; set; }
        public string Method { get; set; }
        public string Succeed { get; set; }
        public int? Userid { get; set; }
    }
}
