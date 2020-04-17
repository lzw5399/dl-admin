using Doublelives.Domain.Infrastructure;

namespace Doublelives.Domain.Cms
{
    public class CmsChannel : AuditableEntityBase
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}
