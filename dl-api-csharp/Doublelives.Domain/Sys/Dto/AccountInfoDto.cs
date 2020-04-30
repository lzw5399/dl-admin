using System.Collections.Generic;

namespace Doublelives.Domain.Sys.Dto
{
    public class AccountInfoDto
    {
        public List<string> Permissions { get; set; }

        /// <summary>
        /// 账户基本信息
        /// </summary>
        public AccountProfileDto Profile { get; set; }

        /// <summary>
        /// 用于显示的用户名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// todo: ？？？
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// 大概是这样的 ["administrator", "developer"]
        /// </summary>
        public List<string> Roles { get; set; }
    }
}