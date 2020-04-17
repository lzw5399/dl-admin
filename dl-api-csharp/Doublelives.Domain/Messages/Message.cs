using Doublelives.Domain.Infrastructure;

namespace Doublelives.Domain.Messages
{
    public class Message : AuditableEntityBase
    {
        public string Content { get; set; }

        public string Receiver { get; set; }

        public string State { get; set; }

        public string TplCode { get; set; }

        public string Type { get; set; }
    }
}
