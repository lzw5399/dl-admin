using Doublelives.Domain.Infrastructure;

namespace Doublelives.Domain.Sys
{
    public class SysRelation : EntityBase
    {
        public int Menuid { get; set; }

        public int Roleid { get; set; }
    }
}
