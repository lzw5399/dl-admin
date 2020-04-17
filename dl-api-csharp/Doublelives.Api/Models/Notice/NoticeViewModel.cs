using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doublelives.Api.Models.Notice
{
    public class NoticeViewModel
    {
        public string Content { get; set; }

        public int CreateBy { get; set; }

        public DateTimeOffset CreateTime { get; set; }

        public int Id { get; set; }

        public int ModifyBy { get; set; }

        public DateTimeOffset ModifyTime { get; set; }

        public string Title { get; set; }

        public int Type { get; set; }
    }
}
