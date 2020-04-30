namespace Doublelives.Api.Models
{
    public class BasePagedListRequest
    {
        /// <summary>
        /// 当前第几页
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 每页的数量
        /// </summary>
        public int Limit { get; set; }
    }
}