namespace Doublelives.Api.Models.Account.Requests
{
    public class AccountLoginRequest
    {
        /// <summary>
        /// �û���
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string Password { get; set; }
    }
}