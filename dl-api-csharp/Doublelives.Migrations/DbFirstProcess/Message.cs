using System;
using System.Collections.Generic;

namespace Doublelives.Migrations.DbFirstProcess
{
    public partial class Message
    {
        public long Id { get; set; }
        public long? CreateBy { get; set; }
        public DateTime? CreateTime { get; set; }
        public long? ModifyBy { get; set; }
        public DateTime? ModifyTime { get; set; }
        public string Content { get; set; }
        public string Receiver { get; set; }
        public string State { get; set; }
        public string TplCode { get; set; }
        public string Type { get; set; }
    }
}
