namespace Doublelives.Domain.Sys.Dto
{
    public class UserSearchDto : BasePagedListDto
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
