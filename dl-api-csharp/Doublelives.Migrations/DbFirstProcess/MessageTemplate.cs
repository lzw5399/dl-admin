using System;
using System.Collections.Generic;

namespace Doublelives.Migrations.DbFirstProcess
{
    public partial class MessageTemplate
    {
        public long Id { get; set; }
        public long? CreateBy { get; set; }
        public DateTime? CreateTime { get; set; }
        public long? ModifyBy { get; set; }
        public DateTime? ModifyTime { get; set; }
        public string Code { get; set; }
        public string Cond { get; set; }
        public string Content { get; set; }
        public long IdMessageSender { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }

        public virtual MessageSender IdMessageSenderNavigation { get; set; }
    }
}
