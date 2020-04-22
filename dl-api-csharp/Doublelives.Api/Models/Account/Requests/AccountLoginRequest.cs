namespace Doublelives.Api.Models.Account.Requests
{
    public class AccountLoginRequest
    {
        /// <summary>
        /// ÓÃ»§Ãû
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// ÃÜÂë
        /// </summary>
        public string Password { get; set; }
    }
}