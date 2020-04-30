using System;

namespace Doublelives.Api.Models.Notice
{
    public class NoticeViewModel
    {
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int Id { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public string Title { get; set; }

        public int? Type { get; set; }
    }
}