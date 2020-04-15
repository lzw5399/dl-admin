namespace Doublelives.Api.Models.Account.Requests
{
    public class AccountUpdatePasswordRequest
    {
        public string OldPassword { get; set; }

        public string Password { get; set; }

        public string RePassword { get; set; }
    }
}