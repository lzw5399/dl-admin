using Doublelives.Domain.Infrastructure;
using System.Collections.Generic;

namespace Doublelives.Domain.Messages
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