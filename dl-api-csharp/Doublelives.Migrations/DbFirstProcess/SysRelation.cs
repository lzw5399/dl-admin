using System;
using System.Collections.Generic;

namespace Doublelives.Migrations.DbFirstProcess
{
    public class SysRelation : EntityBase
    {
        public int? Menuid { get; set; }

        public int? Roleid { get; set; }
    }
}
