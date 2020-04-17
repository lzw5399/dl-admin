using System;
using System.Collections.Generic;

namespace Doublelives.Migrations.DbFirstProcess
{
    public partial  class SysRelation
    {
        public long Id { get; set; }
        public long? Menuid { get; set; }
        public long? Roleid { get; set; }
    }
}
