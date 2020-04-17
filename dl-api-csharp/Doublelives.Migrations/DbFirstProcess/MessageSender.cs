using System;
using System.Collections.Generic;

namespace Doublelives.Migrations.DbFirstProcess
{
    public partial class MessageSender
    {
        public MessageSender()
        {
            MessageTemplate = new HashSet<MessageTemplate>();
        }

        public long Id { get; set; }
        public long? CreateBy { get; set; }
        public DateTime? CreateTime { get; set; }
        public long? ModifyBy { get; set; }
        public DateTime? ModifyTime { get; set; }
        public string ClassName { get; set; }
        public string Name { get; set; }
        public string TplCode { get; set; }

        public virtual ICollection<MessageTemplate> MessageTemplate { get; set; }
    }
}
