using Doublelives.Domain.Infrastructure;

namespace Doublelives.Domain.Cms
{
    public class CmsBanner : AuditableEntityBase
    {
        public int? IdFile { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public string Url { get; set; }
    }
}