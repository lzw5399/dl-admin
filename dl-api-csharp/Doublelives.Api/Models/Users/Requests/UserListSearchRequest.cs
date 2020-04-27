namespace Doublelives.Api.Models.Users.Requests
{
    public class UserListSearchRequest : BasePagedListRequest
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
    }
}
