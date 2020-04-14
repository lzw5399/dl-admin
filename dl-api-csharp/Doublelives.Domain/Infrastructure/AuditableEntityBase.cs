using System;
using System.Collections.Generic;
using System.Text;

namespace Doublelives.Domain.Infrastructure
{
    public class AuditableEntityBase : EntityBase
    {
        protected AuditableEntityBase()
        {
            CreatedDate = DateTime.UtcNow;
        }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }
    }
}
