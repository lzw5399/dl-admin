using System;
using System.Collections.Generic;

namespace Doublelives.Migrations.DbFirstProcess
{
    public partial class Tesgirl
    {
        public long Id { get; set; }
        public long? CreateBy { get; set; }
        public DateTime? CreateTime { get; set; }
        public long? ModifyBy { get; set; }
        public DateTime? ModifyTime { get; set; }
        public int? Age { get; set; }
        public DateTime? Birthday { get; set; }
        public sbyte? HasBoyFriend { get; set; }
        public string Name { get; set; }
    }
}
