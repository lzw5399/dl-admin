using Doublelives.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doublelives.Domain.Users.Dto
{
    public class CurrentUserDto
    {
        public int Id { get; set; }

        public Role Role { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Language { get; set; }
    }
}
