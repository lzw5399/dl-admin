using Doublelives.Shared.Enum;

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