using Doublelives.Shared.Enum;
using System;

namespace Doublelives.Api.Models.Users.Requests
{
    public class UserUpdateRequest
    {
        public int Id { get; set; }

        public string Account { get; set; }

        public Gender Sex { get; set; }

        public string Phone { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int Deptid { get; set; }

        public DateTime Birthday { get; set; }

        public bool Status { get; set; }
    }
}
