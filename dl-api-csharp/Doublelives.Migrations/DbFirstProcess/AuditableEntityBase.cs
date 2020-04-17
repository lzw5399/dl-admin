using System;
using System.Collections.Generic;
using System.Text;

namespace Doublelives.Migrations.DbFirstProcess
{
    public class AuditableEntityBase : EntityBase
    {
        protected AuditableEntityBase()
        {
            CreateTime = DateTime.Now;
        }

        public DateTime CreateTime { get; set; }

        public string CreateBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public string ModifyBy { get; set; }
    }
}
