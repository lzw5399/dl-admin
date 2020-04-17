using System;
using System.Collections.Generic;

namespace Doublelives.Migrations.DbFirstProcess
{
    public partial class SysFileInfo
    {
        public long Id { get; set; }
        public long? CreateBy { get; set; }
        public DateTime? CreateTime { get; set; }
        public long? ModifyBy { get; set; }
        public DateTime? ModifyTime { get; set; }
        public string OriginalFileName { get; set; }
        public string RealFileName { get; set; }
    }
}
