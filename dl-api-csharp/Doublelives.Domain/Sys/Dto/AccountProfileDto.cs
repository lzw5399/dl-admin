using Doublelives.Shared.Enum;
using System;
using System.Collections.Generic;

namespace Doublelives.Domain.Sys.Dto
{
    /// <summary>
    /// 账户信息
    /// </summary>
    public class AccountProfileDto
    {
        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// 登录账户名(username)
        /// </summary>
        public string Account { get; set; }

        public string Password { get; set; }

        /// <summary>
        /// 盐值
        /// </summary>
        public string Salt { get; set; }

        /// <summary>
        /// 用于显示的用户名
        /// </summary>
        public string Name { get; set; }

        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 性别 1男 2女
        /// </summary>
        public int? Sex { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        /// <summary>
        /// 角色id， 多个以逗号区分 e.g. (1,2,)
        /// </summary>
        public string Roleid { get; set; }

        /// <summary>
        /// 部门id
        /// </summary>
        public int Deptid { get; set; }

        /// <summary>
        /// 账号状态 1激活 2停用
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 修改的版本
        /// </summary>
        public int? Version { get; set; }

        /// <summary>
        /// 角色id
        /// </summary>
        public int Id { get; set; }

        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 创建人的id
        /// </summary>
        public int? CreateBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        /// <summary>
        /// 修改者的id
        /// </summary>
        public int? ModifyBy { get; set; }

        /// <summary>
        /// 部门名
        /// </summary>
        public string Dept { get; set; }

        /// <summary>
        /// 角色名的数据 e.g.["超级管理员", "网站管理员"]
        /// </summary>
        public List<string> Roles { get; set; }

        public string DeptName { get; set; }

        public string RoleName { get; set; }

        public string StatusName => Status == (int)AccountStatus.Active ? "启用" : "禁用";

        public string SexName => Sex.HasValue ? (Sex.Value == (int)Gender.Male ? "男" : "女") : string.Empty;
    }
}
