using System;
using System.Collections.Generic;

namespace Doublelives.Migrations.DbFirstProcess
{
    public class SysMenu : AuditableEntityBase
    {
        public string Code { get; set; }

        public string Component { get; set; }

        public sbyte? Hidden { get; set; }

        public string Icon { get; set; }

        public int Ismenu { get; set; }

        public int? Isopen { get; set; }

        public int Levels { get; set; }

        public string Name { get; set; }

        public int Num { get; set; }

        public string Pcode { get; set; }

        public string Pcodes { get; set; }

        public int Status { get; set; }

        public string Tips { get; set; }

        public string Url { get; set; }
    }
}
