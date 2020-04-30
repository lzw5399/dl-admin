using Doublelives.Domain.Infrastructure;
using Doublelives.Shared.Enum;

namespace Doublelives.Domain.Messages
{
    public class Message : AuditableEntityBase
    {
        public string Content { get; set; }

        public string Receiver { get; set; }

        public MessageStatus State { get; set; }

        public string TplCode { get; set; }

        public MessageType Type { get; set; }
    }
}