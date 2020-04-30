using Doublelives.Domain.Infrastructure;

namespace Doublelives.Domain.Sys
{
    public class SysCfg : AuditableEntityBase
    {
        public string CfgDesc { get; set; }

        public string CfgName { get; set; }

        public string CfgValue { get; set; }
    }
}