using System;
using System.Collections.Generic;

namespace Doublelives.Migrations.DbFirstProcess
{
    public partial class SysLoginLog
    {
        public int Id { get; set; }
        public DateTime? CreateTime { get; set; }
        public string Ip { get; set; }
        public string Logname { get; set; }
        public string Message { get; set; }
        public string Succeed { get; set; }
        public int? Userid { get; set; }
    }
}
