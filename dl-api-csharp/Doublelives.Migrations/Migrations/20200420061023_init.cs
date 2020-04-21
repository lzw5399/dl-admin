using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Doublelives.Migrations.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cms_article",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "创建时间/注册时间"),
                    create_by = table.Column<long>(type: "bigint(20)", nullable: true, comment: "创建人"),
                    modify_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "最后更新时间"),
                    modify_by = table.Column<long>(type: "bigint(20)", nullable: true, comment: "最后更新人"),
                    author = table.Column<string>(type: "varchar(64)", nullable: true, comment: "作者")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    content = table.Column<string>(type: "text", nullable: true, comment: "内容")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    id_channel = table.Column<long>(type: "bigint(20)", nullable: false, comment: "栏目id"),
                    img = table.Column<string>(type: "varchar(64)", nullable: true, comment: "文章题图ID")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    title = table.Column<string>(type: "varchar(128)", nullable: true, comment: "标题")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_article", x => x.id);
                },
                comment: "文章");

            migrationBuilder.CreateTable(
                name: "cms_banner",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "创建时间/注册时间"),
                    create_by = table.Column<long>(type: "bigint(20)", nullable: true, comment: "创建人"),
                    modify_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "最后更新时间"),
                    modify_by = table.Column<long>(type: "bigint(20)", nullable: true, comment: "最后更新人"),
                    id_file = table.Column<long>(type: "bigint(20)", nullable: true, comment: "banner图id"),
                    title = table.Column<string>(type: "varchar(64)", nullable: true, comment: "标题")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    type = table.Column<string>(type: "varchar(32)", nullable: true, comment: "类型")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    url = table.Column<string>(type: "varchar(128)", nullable: true, comment: "点击banner跳转到url")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_banner", x => x.id);
                },
                comment: "Banner");

            migrationBuilder.CreateTable(
                name: "cms_channel",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "创建时间/注册时间"),
                    create_by = table.Column<long>(type: "bigint(20)", nullable: true, comment: "创建人"),
                    modify_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "最后更新时间"),
                    modify_by = table.Column<long>(type: "bigint(20)", nullable: true, comment: "最后更新人"),
                    code = table.Column<string>(type: "varchar(64)", nullable: true, comment: "编码")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    name = table.Column<string>(type: "varchar(64)", nullable: true, comment: "名称")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_channel", x => x.id);
                },
                comment: "文章栏目");

            migrationBuilder.CreateTable(
                name: "cms_contacts",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "创建时间/注册时间"),
                    create_by = table.Column<long>(type: "bigint(20)", nullable: true, comment: "创建人"),
                    modify_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "最后更新时间"),
                    modify_by = table.Column<long>(type: "bigint(20)", nullable: true, comment: "最后更新人"),
                    email = table.Column<string>(type: "varchar(32)", nullable: true, comment: "电子邮箱")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    mobile = table.Column<string>(type: "varchar(64)", nullable: true, comment: "联系电话")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    remark = table.Column<string>(type: "varchar(128)", nullable: true, comment: "备注")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    user_name = table.Column<string>(type: "varchar(64)", nullable: true, comment: "邀约人名称")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_contacts", x => x.id);
                },
                comment: "邀约信息");

            migrationBuilder.CreateTable(
                name: "message",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "创建时间/注册时间"),
                    create_by = table.Column<long>(type: "bigint(20)", nullable: true, comment: "创建人"),
                    modify_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "最后更新时间"),
                    modify_by = table.Column<long>(type: "bigint(20)", nullable: true, comment: "最后更新人"),
                    content = table.Column<string>(type: "text", nullable: true, comment: "消息内容")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    receiver = table.Column<string>(type: "varchar(64)", nullable: true, comment: "接收者")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    state = table.Column<string>(type: "varchar(32)", nullable: true, comment: "消息类型,0:初始,1:成功,2:失败")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    tpl_code = table.Column<string>(type: "varchar(32)", nullable: true, comment: "模板编码")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    type = table.Column<string>(type: "varchar(32)", nullable: true, comment: "消息类型,0:短信,1:邮件")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_message", x => x.id);
                },
                comment: "历史消息");

            migrationBuilder.CreateTable(
                name: "message_sender",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "创建时间/注册时间"),
                    create_by = table.Column<long>(type: "bigint(20)", nullable: true, comment: "创建人"),
                    modify_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "最后更新时间"),
                    modify_by = table.Column<long>(type: "bigint(20)", nullable: true, comment: "最后更新人"),
                    class_name = table.Column<string>(type: "varchar(64)", nullable: true, comment: "发送类")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    name = table.Column<string>(type: "varchar(64)", nullable: true, comment: "名称")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    tpl_code = table.Column<string>(type: "varchar(64)", nullable: true, comment: "短信运营商模板编号")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_message_sender", x => x.id);
                },
                comment: "消息发送者");

            migrationBuilder.CreateTable(
                name: "sys_cfg",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "创建时间/注册时间"),
                    create_by = table.Column<long>(type: "bigint(20)", nullable: true, comment: "创建人"),
                    modify_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "最后更新时间"),
                    modify_by = table.Column<long>(type: "bigint(20)", nullable: true, comment: "最后更新人"),
                    cfg_desc = table.Column<string>(type: "text", nullable: true, comment: "备注")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    cfg_name = table.Column<string>(type: "varchar(256)", nullable: true, comment: "参数名")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    cfg_value = table.Column<string>(type: "varchar(512)", nullable: true, comment: "参数值")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_cfg", x => x.id);
                },
                comment: "系统参数");

            migrationBuilder.CreateTable(
                name: "sys_dept",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "创建时间/注册时间"),
                    create_by = table.Column<long>(type: "bigint(20)", nullable: true, comment: "创建人"),
                    modify_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "最后更新时间"),
                    modify_by = table.Column<long>(type: "bigint(20)", nullable: true, comment: "最后更新人"),
                    fullname = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    num = table.Column<int>(type: "int(11)", nullable: true),
                    pid = table.Column<long>(type: "bigint(20)", nullable: true),
                    pids = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    simplename = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    tips = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    version = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_dept", x => x.id);
                },
                comment: "部门");

            migrationBuilder.CreateTable(
                name: "sys_dict",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "创建时间/注册时间"),
                    create_by = table.Column<long>(type: "bigint(20)", nullable: true, comment: "创建人"),
                    modify_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "最后更新时间"),
                    modify_by = table.Column<long>(type: "bigint(20)", nullable: true, comment: "最后更新人"),
                    name = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    num = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    pid = table.Column<long>(type: "bigint(20)", nullable: true),
                    tips = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_dict", x => x.id);
                },
                comment: "字典");

            migrationBuilder.CreateTable(
                name: "sys_file_info",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "创建时间/注册时间"),
                    create_by = table.Column<long>(type: "bigint(20)", nullable: true, comment: "创建人"),
                    modify_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "最后更新时间"),
                    modify_by = table.Column<long>(type: "bigint(20)", nullable: true, comment: "最后更新人"),
                    original_file_name = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    real_file_name = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_file_info", x => x.id);
                },
                comment: "文件");

            migrationBuilder.CreateTable(
                name: "sys_login_log",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false),
                    create_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "创建时间"),
                    ip = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    logname = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    message = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    succeed = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    userid = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_login_log", x => x.id);
                },
                comment: "登录日志");

            migrationBuilder.CreateTable(
                name: "sys_menu",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "创建时间/注册时间"),
                    create_by = table.Column<long>(type: "bigint(20)", nullable: true, comment: "创建人"),
                    modify_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "最后更新时间"),
                    modify_by = table.Column<long>(type: "bigint(20)", nullable: true, comment: "最后更新人"),
                    code = table.Column<string>(type: "varchar(32)", nullable: false, comment: "编号")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    component = table.Column<string>(type: "varchar(64)", nullable: true, comment: "页面组件")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    hidden = table.Column<sbyte>(type: "tinyint(4)", nullable: false, comment: "是否隐藏"),
                    icon = table.Column<string>(type: "varchar(32)", nullable: true, comment: "图标")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    ismenu = table.Column<int>(type: "int(11)", nullable: false, comment: "是否是菜单1:菜单,0:按钮"),
                    isopen = table.Column<int>(type: "int(11)", nullable: true, comment: "是否默认打开1:是,0:否"),
                    levels = table.Column<int>(type: "int(11)", nullable: false, comment: "级别"),
                    name = table.Column<string>(type: "varchar(64)", nullable: false, comment: "名称")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    num = table.Column<int>(type: "int(11)", nullable: false, comment: "顺序"),
                    pcode = table.Column<string>(type: "varchar(64)", nullable: false, comment: "父菜单编号")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    pcodes = table.Column<string>(type: "varchar(128)", nullable: true, comment: "递归父级菜单编号")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    status = table.Column<int>(type: "int(11)", nullable: false, comment: "状态1:启用,0:禁用"),
                    tips = table.Column<string>(type: "varchar(32)", nullable: true, comment: "鼠标悬停提示信息")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    url = table.Column<string>(type: "varchar(32)", nullable: true, comment: "链接标识")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_menu", x => x.id);
                },
                comment: "菜单");

            migrationBuilder.CreateTable(
                name: "sys_notice",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "创建时间/注册时间"),
                    create_by = table.Column<long>(type: "bigint(20)", nullable: true, comment: "创建人"),
                    modify_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "最后更新时间"),
                    modify_by = table.Column<long>(type: "bigint(20)", nullable: true, comment: "最后更新人"),
                    content = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    title = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    type = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_notice", x => x.id);
                },
                comment: "通知");

            migrationBuilder.CreateTable(
                name: "sys_operation_log",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    classname = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    create_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    logname = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    logtype = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    message = table.Column<string>(type: "text", nullable: true, comment: "详细信息")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    method = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    succeed = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    userid = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_operation_log", x => x.id);
                },
                comment: "操作日志");

            migrationBuilder.CreateTable(
                name: "sys_relation",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    menuid = table.Column<long>(type: "bigint(20)", nullable: false),
                    roleid = table.Column<long>(type: "bigint(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_relation", x => x.id);
                },
                comment: "菜单角色关系");

            migrationBuilder.CreateTable(
                name: "sys_role",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "创建时间/注册时间"),
                    create_by = table.Column<long>(type: "bigint(20)", nullable: true, comment: "创建人"),
                    modify_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "最后更新时间"),
                    modify_by = table.Column<long>(type: "bigint(20)", nullable: true, comment: "最后更新人"),
                    deptid = table.Column<long>(type: "bigint(20)", nullable: true),
                    name = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    num = table.Column<int>(type: "int(11)", nullable: true),
                    pid = table.Column<long>(type: "bigint(20)", nullable: true),
                    tips = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    version = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_role", x => x.id);
                },
                comment: "角色");

            migrationBuilder.CreateTable(
                name: "sys_task",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "创建时间/注册时间"),
                    create_by = table.Column<long>(type: "bigint(20)", nullable: true, comment: "创建人"),
                    modify_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "最后更新时间"),
                    modify_by = table.Column<long>(type: "bigint(20)", nullable: true, comment: "最后更新人"),
                    concurrent = table.Column<sbyte>(type: "tinyint(4)", nullable: true, comment: "是否允许并发"),
                    cron = table.Column<string>(type: "varchar(50)", nullable: true, comment: "定时规则")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    data = table.Column<string>(type: "text", nullable: true, comment: "执行参数")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    disabled = table.Column<sbyte>(type: "tinyint(4)", nullable: true, comment: "是否禁用"),
                    exec_at = table.Column<DateTime>(type: "datetime", nullable: true, comment: "执行时间"),
                    exec_result = table.Column<string>(type: "text", nullable: true, comment: "执行结果")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    job_class = table.Column<string>(type: "varchar(255)", nullable: true, comment: "执行类")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    job_group = table.Column<string>(type: "varchar(50)", nullable: true, comment: "任务组名")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    name = table.Column<string>(type: "varchar(50)", nullable: true, comment: "任务名")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    note = table.Column<string>(type: "varchar(255)", nullable: true, comment: "任务说明")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_task", x => x.id);
                },
                comment: "定时任务");

            migrationBuilder.CreateTable(
                name: "sys_task_log",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    exec_at = table.Column<DateTime>(type: "datetime", nullable: true, comment: "执行时间"),
                    exec_success = table.Column<int>(type: "int(11)", nullable: true, comment: "执行结果（成功:1、失败:0)"),
                    id_task = table.Column<long>(type: "bigint(20)", nullable: true),
                    job_exception = table.Column<string>(type: "varchar(500)", nullable: true, comment: "抛出异常")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    name = table.Column<string>(type: "varchar(50)", nullable: true, comment: "任务名")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_task_log", x => x.id);
                },
                comment: "定时任务日志");

            migrationBuilder.CreateTable(
                name: "sys_user",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "创建时间/注册时间"),
                    create_by = table.Column<long>(type: "bigint(20)", nullable: true, comment: "创建人"),
                    modify_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "最后更新时间"),
                    modify_by = table.Column<long>(type: "bigint(20)", nullable: true, comment: "最后更新人"),
                    account = table.Column<string>(type: "varchar(32)", nullable: true, comment: "账户")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    avatar = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    birthday = table.Column<DateTime>(type: "datetime", nullable: true),
                    deptid = table.Column<long>(type: "bigint(20)", nullable: true),
                    email = table.Column<string>(type: "varchar(64)", nullable: true, comment: "email")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    name = table.Column<string>(type: "varchar(64)", nullable: true, comment: "姓名")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    password = table.Column<string>(type: "varchar(64)", nullable: true, comment: "密码")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    phone = table.Column<string>(type: "varchar(16)", nullable: true, comment: "手机号")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    roleid = table.Column<string>(type: "varchar(128)", nullable: true, comment: "角色id列表，以逗号分隔")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    salt = table.Column<string>(type: "varchar(16)", nullable: true, comment: "密码盐")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    sex = table.Column<int>(type: "int(11)", nullable: true),
                    status = table.Column<int>(type: "int(11)", nullable: true),
                    version = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_user", x => x.id);
                },
                comment: "账号");

            migrationBuilder.CreateTable(
                name: "message_template",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "创建时间/注册时间"),
                    create_by = table.Column<long>(type: "bigint(20)", nullable: true, comment: "创建人"),
                    modify_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "最后更新时间"),
                    modify_by = table.Column<long>(type: "bigint(20)", nullable: true, comment: "最后更新人"),
                    code = table.Column<string>(type: "varchar(32)", nullable: true, comment: "编号")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    cond = table.Column<string>(type: "varchar(32)", nullable: true, comment: "发送条件")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    content = table.Column<string>(type: "text", nullable: true, comment: "内容")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    id_message_sender = table.Column<long>(type: "bigint(20)", nullable: false, comment: "发送者id"),
                    title = table.Column<string>(type: "varchar(64)", nullable: true, comment: "标题")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    type = table.Column<string>(type: "varchar(32)", nullable: true, comment: "消息类型,0:短信,1:邮件")
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_message_template", x => x.id);
                    table.ForeignKey(
                        name: "FK942sadqk5x9kbrwil0psyek3n",
                        column: x => x.id_message_sender,
                        principalTable: "message_sender",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "消息模板");

            migrationBuilder.CreateIndex(
                name: "FK942sadqk5x9kbrwil0psyek3n",
                table: "message_template",
                column: "id_message_sender");

            migrationBuilder.CreateIndex(
                name: "UK_s37unj3gh67ujhk83lqva8i1t",
                table: "sys_menu",
                column: "code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cms_article");

            migrationBuilder.DropTable(
                name: "cms_banner");

            migrationBuilder.DropTable(
                name: "cms_channel");

            migrationBuilder.DropTable(
                name: "cms_contacts");

            migrationBuilder.DropTable(
                name: "message");

            migrationBuilder.DropTable(
                name: "message_template");

            migrationBuilder.DropTable(
                name: "sys_cfg");

            migrationBuilder.DropTable(
                name: "sys_dept");

            migrationBuilder.DropTable(
                name: "sys_dict");

            migrationBuilder.DropTable(
                name: "sys_file_info");

            migrationBuilder.DropTable(
                name: "sys_login_log");

            migrationBuilder.DropTable(
                name: "sys_menu");

            migrationBuilder.DropTable(
                name: "sys_notice");

            migrationBuilder.DropTable(
                name: "sys_operation_log");

            migrationBuilder.DropTable(
                name: "sys_relation");

            migrationBuilder.DropTable(
                name: "sys_role");

            migrationBuilder.DropTable(
                name: "sys_task");

            migrationBuilder.DropTable(
                name: "sys_task_log");

            migrationBuilder.DropTable(
                name: "sys_user");

            migrationBuilder.DropTable(
                name: "message_sender");
        }
    }
}
