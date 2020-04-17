using System;
using System.Collections.Generic;

namespace Doublelives.Migrations.DbFirstProcess
{
    public class Tesboy : AuditableEntityBase
    {
        public int? Age { get; set; }

        public string Birthday { get; set; }

        public sbyte? HasGirlFriend { get; set; }

        public string Name { get; set; }
    }
}
