using Doublelives.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doublelives.Api.Models.Users
{
    public class UserViewModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public Role Role { get; set; }

        public string LanguageCode { get; set; }
    }
}
