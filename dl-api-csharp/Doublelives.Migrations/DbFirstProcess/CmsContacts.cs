using System;
using System.Collections.Generic;

namespace Doublelives.Migrations.DbFirstProcess
{
    public partial class CmsContacts
    {
        public long Id { get; set; }
        public long? CreateBy { get; set; }
        public DateTime? CreateTime { get; set; }
        public long? ModifyBy { get; set; }
        public DateTime? ModifyTime { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Remark { get; set; }
        public string UserName { get; set; }
    }
}
