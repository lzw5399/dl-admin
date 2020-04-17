using System;
using System.Collections.Generic;

namespace Doublelives.Migrations.DbFirstProcess
{
    public class SysRelation : EntityBase
    {
        public long? Menuid { get; set; }

        public long? Roleid { get; set; }
    }
}
