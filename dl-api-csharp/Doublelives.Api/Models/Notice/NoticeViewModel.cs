using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doublelives.Api.Models.Notice
{
    public class NoticeViewModel
    {
        public string Content { get; set; }

        public long CreateBy { get; set; }

        public DateTimeOffset CreateTime { get; set; }

        public long Id { get; set; }

        public long ModifyBy { get; set; }

        public DateTimeOffset ModifyTime { get; set; }

        public string Title { get; set; }

        public long Type { get; set; }
    }
}
