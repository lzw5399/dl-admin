using Doublelives.Shared.Enum;
using System;
using System.Collections.Generic;

namespace Doublelives.Api.Models.Account
{
    public class AccountInfoViewModel
    {
        public List<string> Permissions { get; set; }

        /// <summary>
        /// 账户基本信息
        /// </summary>
        public AccountProfileViewModel Profile { get; set; }

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

    /// <summary>
    /// 账户信息
    /// </summary>
    public class AccountProfileViewModel
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
        public long Deptid { get; set; }

        /// <summary>
        /// 账号状态 1激活 2停用
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 修改的版本
        /// </summary>
        public long? Version { get; set; }

        /// <summary>
        /// 角色id
        /// </summary>
        public long Id { get; set; }

        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 创建人的id
        /// </summary>
        public long? CreateBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        /// <summary>
        /// 修改者的id
        /// </summary>
        public long? ModifyBy { get; set; }

        /// <summary>
        /// 部门名
        /// </summary>
        public string Dept { get; set; }

        /// <summary>
        /// 角色名的数据 e.g.["超级管理员", "网站管理员"]
        /// </summary>
        public List<string> Roles { get; set; }
    }
}