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

        public int? CreateBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public int? ModifyBy { get; set; }
    }
}