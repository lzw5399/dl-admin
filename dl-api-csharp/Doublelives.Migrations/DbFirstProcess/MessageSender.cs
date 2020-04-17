using System;
using System.Collections.Generic;

namespace Doublelives.Migrations.DbFirstProcess
{
    public class MessageSender : AuditableEntityBase
    {
        public MessageSender()
        {
            MessageTemplate = new HashSet<MessageTemplate>();
        }

        public string ClassName { get; set; }

        public string Name { get; set; }

        public string TplCode { get; set; }

        public virtual ICollection<MessageTemplate> MessageTemplate { get; set; }
    }
}
