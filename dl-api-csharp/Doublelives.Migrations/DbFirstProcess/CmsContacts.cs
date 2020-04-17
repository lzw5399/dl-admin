using System;
using System.Collections.Generic;

namespace Doublelives.Migrations.DbFirstProcess
{
    public class CmsContacts : AuditableEntityBase
    {
        public string Email { get; set; }

        public string Mobile { get; set; }

        public string Remark { get; set; }

        public string UserName { get; set; }
    }
}
