using System;

namespace Doublelives.Domain.Sys.Dto
{
    public class CfgDto
    {
        public int Id { get; set; }

        public string CfgDesc { get; set; }

        public string CfgName { get; set; }

        public string CfgValue { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public int? ModifyBy { get; set; }
    }
}