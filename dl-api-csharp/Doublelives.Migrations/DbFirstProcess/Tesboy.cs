using System;
using System.Collections.Generic;

namespace Doublelives.Migrations.DbFirstProcess
{
    public partial class Tesboy
    {
        public long Id { get; set; }
        public long? CreateBy { get; set; }
        public DateTime? CreateTime { get; set; }
        public long? ModifyBy { get; set; }
        public DateTime? ModifyTime { get; set; }
        public int? Age { get; set; }
        public string Birthday { get; set; }
        public sbyte? HasGirlFriend { get; set; }
        public string Name { get; set; }
    }
}
