using System;

namespace Doublelives.Domain.Infrastructure
{
    public class AuditableEntityBase : EntityBase
    {
        protected AuditableEntityBase()
        {
            CreateTime = DateTime.Now;
        }

        public DateTime? CreateTime { get; set; }

        public long? CreateBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public long? ModifyBy { get; set; }
    }
}
