using System;

namespace Doublelives.Api.Models.Dicts
{
    public class DictViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Num { get; set; }

        /// <summary>
        /// 上级dict的id
        /// </summary>
        public int? Pid { get; set; }

        /// <summary>
        /// 所有的下级的字典内容的信息 e.g."1:启用,2:禁用"
        /// </summary>
        public string Detail { get; set; }

        public string Tips { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public int? ModifyBy { get; set; }
    }
}