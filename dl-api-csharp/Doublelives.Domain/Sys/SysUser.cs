using Doublelives.Domain.Infrastructure;
using Doublelives.Shared.Enum;
using System;

namespace Doublelives.Domain.Sys
{
    public class SysUser : AuditableEntityBase
    {
        public string Account { get; set; }

        public string Avatar { get; set; }

        public DateTime? Birthday { get; set; }

        public int? Deptid { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string Roleid { get; set; }

        public string Salt { get; set; }

        public Gender? Sex { get; set; }

        public AccountStatus? Status { get; set; }

        public int? Version { get; set; }
    }
}