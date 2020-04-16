using Doublelives.Shared.Enum;
using System;
using System.Collections.Generic;

namespace Doublelives.Api.Models.Account
{
    public class AccountViewModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public Role Role { get; set; }

        public string LanguageCode { get; set; }
    }

    public class AccountData
    {
        public List<string> Permissions { get; set; }

        public AccountProfile Profile { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public List<string> Roles { get; set; }
    }

    public class AccountProfile
    {
        public string Avatar { get; set; }

        public string Account { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public string Name { get; set; }

        public DateTimeOffset Birthday { get; set; }

        public long Sex { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public long Roleid { get; set; }

        public long Deptid { get; set; }

        public long Status { get; set; }

        public long Version { get; set; }

        public long Id { get; set; }

        public DateTimeOffset CreateTime { get; set; }

        public string CreateBy { get; set; }

        public DateTimeOffset ModifyTime { get; set; }

        public long ModifyBy { get; set; }

        public string Dept { get; set; }

        public List<string> Roles { get; set; }
    }
}