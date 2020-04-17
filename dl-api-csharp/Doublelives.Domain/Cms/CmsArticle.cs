using Doublelives.Domain.Infrastructure;

namespace Doublelives.Domain.Cms
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
