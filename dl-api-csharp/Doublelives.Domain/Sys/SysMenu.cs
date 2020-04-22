using Doublelives.Domain.Infrastructure;
using Doublelives.Shared.Enum;

namespace Doublelives.Domain.Sys
{
    public class SysMenu : AuditableEntityBase
    {
        public string Code { get; set; }

        public string Component { get; set; }

        public bool Hidden { get; set; }

        public string Icon { get; set; }

        public bool Ismenu { get; set; }

        public bool? Isopen { get; set; }

        public int Levels { get; set; }

        public string Name { get; set; }

        public int Num { get; set; }

        public string Pcode { get; set; }

        public string Pcodes { get; set; }

        public MenuStatus Status { get; set; }

        public string Tips { get; set; }

        public string Url { get; set; }
    }
}
