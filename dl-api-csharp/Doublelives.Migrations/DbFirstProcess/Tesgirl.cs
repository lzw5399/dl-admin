using System;
using System.Collections.Generic;

namespace Doublelives.Migrations.DbFirstProcess
{
    public class Tesgirl : AuditableEntityBase
    {
        public int? Age { get; set; }

        public DateTime? Birthday { get; set; }

        public sbyte? HasBoyFriend { get; set; }

        public string Name { get; set; }
    }
}
