using Doublelives.Domain.Infrastructure;
using Doublelives.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doublelives.Domain.Users
{
    public class User : AuditableEntityBase
    {
        public User()
        {
            IsDeleted = false;
            Role = Role.User;
        }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }

        public string LanguageCode { get; set; }

        public bool IsDeleted { get; set; }
    }
}