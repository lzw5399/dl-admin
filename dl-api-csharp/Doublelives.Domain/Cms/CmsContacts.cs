using Doublelives.Domain.Infrastructure;

namespace Doublelives.Domain.Cms
{
    public class CmsContacts : AuditableEntityBase
    {
        public string Email { get; set; }

        public string Mobile { get; set; }

        public string Remark { get; set; }

        public string UserName { get; set; }
    }
}
