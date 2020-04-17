using System;
using System.Collections.Generic;

namespace Doublelives.Migrations.DbFirstProcess
{
    public class CmsArticle : AuditableEntityBase
    {
        public string Author { get; set; }

        public string Content { get; set; }

        public int IdChannel { get; set; }

        public string Img { get; set; }

        public string Title { get; set; }
    }
}
