using System;
using System.Collections.Generic;

namespace Doublelives.Migrations.DbFirstProcess
{
    public          class CmsArticle
    {
        public long Id { get; set; }
        public long? CreateBy { get; set; }
        public DateTime? CreateTime { get; set; }
        public long? ModifyBy { get; set; }
        public DateTime? ModifyTime { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public long IdChannel { get; set; }
        public string Img { get; set; }
        public string Title { get; set; }
    }
}
