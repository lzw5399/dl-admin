using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Doublelives.Migrations.Migrations
{
    public partial class reinit_mysql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cms_article",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false, comment: "主键")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: true, comment: "创建时间"),
                    create_by = table.Column<int>(nullable: true, comment: "创建者"),
                    modify_time = table.Column<DateTime>(nullable: true, comment: "最后修改时间"),
                    modify_by = table.Column<int>(nullable: true, comment: "最后修改者"),
                    author = table.Column<string>(maxLength: 64, nullable: true, comment: "作者"),
                    content = table.Column<string>(maxLength: 65535, nullable: true, comment: "内容"),
                    id_channel = table.Column<int>(nullable: false, comment: "栏目id"),
                    img = table.Column<string>(maxLength: 64, nullable: true, comment: "文章题图id"),
                    title = table.Column<string>(maxLength: 128, nullable: true, comment: "文章标题")
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
                    id = table.Column<int>(nullable: false, comment: "主键")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: true, comment: "创建时间"),
                    create_by = table.Column<int>(nullable: true, comment: "创建者"),
                    modify_time = table.Column<DateTime>(nullable: true, comment: "最后修改时间"),
                    modify_by = table.Column<int>(nullable: true, comment: "最后修改者"),
                    id_file = table.Column<int>(nullable: true, comment: "banner图id"),
                    title = table.Column<string>(maxLength: 64, nullable: true, comment: "标题"),
                    type = table.Column<string>(maxLength: 32, nullable: true, comment: "类型"),
                    url = table.Column<string>(maxLength: 128, nullable: true, comment: "点击banner跳转到url")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_banner", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cms_channel",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false, comment: "主键")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: true, comment: "创建时间"),
                    create_by = table.Column<int>(nullable: true, comment: "创建者"),
                    modify_time = table.Column<DateTime>(nullable: true, comment: "最后修改时间"),
                    modify_by = table.Column<int>(nullable: true, comment: "最后修改者"),
                    code = table.Column<string>(maxLength: 64, nullable: true, comment: "编码"),
                    name = table.Column<string>(maxLength: 64, nullable: true, comment: "名称")
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
                    id = table.Column<int>(nullable: false, comment: "主键")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: true, comment: "创建时间"),
                    create_by = table.Column<int>(nullable: true, comment: "创建者"),
                    modify_time = table.Column<DateTime>(nullable: true, comment: "最后修改时间"),
                    modify_by = table.Column<int>(nullable: true, comment: "最后修改者"),
                    email = table.Column<string>(maxLength: 32, nullable: true, comment: "邮箱"),
                    mobile = table.Column<string>(maxLength: 64, nullable: true, comment: "联系电话"),
                    remark = table.Column<string>(maxLength: 128, nullable: true, comment: "备注"),
                    user_name = table.Column<string>(maxLength: 64, nullable: true, comment: "邀约人名称")
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
                    id = table.Column<int>(nullable: false, comment: "主键")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: true, comment: "创建时间"),
                    create_by = table.Column<int>(nullable: true, comment: "创建者"),
                    modify_time = table.Column<DateTime>(nullable: true, comment: "最后修改时间"),
                    modify_by = table.Column<int>(nullable: true, comment: "最后修改者"),
                    content = table.Column<string>(maxLength: 65535, nullable: true, comment: "消息内容"),
                    receiver = table.Column<string>(maxLength: 64, nullable: true, comment: "接收者"),
                    state = table.Column<int>(nullable: false, comment: "消息类型,0:初始,1:成功,2:失败"),
                    tpl_code = table.Column<string>(maxLength: 32, nullable: true, comment: "模板编码"),
                    type = table.Column<int>(nullable: false, comment: "消息类型,0:短信,1:邮件")
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
                    id = table.Column<int>(nullable: false, comment: "主键")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: true, comment: "创建时间"),
                    create_by = table.Column<int>(nullable: true, comment: "创建者"),
                    modify_time = table.Column<DateTime>(nullable: true, comment: "最后修改时间"),
                    modify_by = table.Column<int>(nullable: true, comment: "最后修改者"),
                    class_name = table.Column<string>(maxLength: 64, nullable: true, comment: "发送类"),
                    name = table.Column<string>(maxLength: 64, nullable: true, comment: "名称"),
                    tpl_code = table.Column<string>(maxLength: 64, nullable: true, comment: "运营商模板编号")
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
                    id = table.Column<int>(nullable: false, comment: "主键")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: true, comment: "创建时间"),
                    create_by = table.Column<int>(nullable: true, comment: "创建者"),
                    modify_time = table.Column<DateTime>(nullable: true, comment: "最后修改时间"),
                    modify_by = table.Column<int>(nullable: true, comment: "最后修改者"),
                    cfg_desc = table.Column<string>(maxLength: 65535, nullable: true, comment: "备注"),
                    cfg_name = table.Column<string>(maxLength: 256, nullable: true, comment: "参数名"),
                    cfg_value = table.Column<string>(maxLength: 512, nullable: true, comment: "参数值")
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
                    id = table.Column<int>(nullable: false, comment: "主键")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: true, comment: "创建时间"),
                    create_by = table.Column<int>(nullable: true, comment: "创建者"),
                    modify_time = table.Column<DateTime>(nullable: true, comment: "最后修改时间"),
                    modify_by = table.Column<int>(nullable: true, comment: "最后修改者"),
                    fullname = table.Column<string>(maxLength: 255, nullable: true, comment: "全称"),
                    num = table.Column<int>(nullable: true),
                    pid = table.Column<int>(nullable: true),
                    pids = table.Column<string>(maxLength: 255, nullable: true),
                    simplename = table.Column<string>(maxLength: 255, nullable: true, comment: "简称"),
                    tips = table.Column<string>(maxLength: 255, nullable: true),
                    version = table.Column<int>(nullable: true)
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
                    id = table.Column<int>(nullable: false, comment: "主键")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: true, comment: "创建时间"),
                    create_by = table.Column<int>(nullable: true, comment: "创建者"),
                    modify_time = table.Column<DateTime>(nullable: true, comment: "最后修改时间"),
                    modify_by = table.Column<int>(nullable: true, comment: "最后修改者"),
                    name = table.Column<string>(maxLength: 255, nullable: true),
                    num = table.Column<string>(maxLength: 255, nullable: true),
                    pid = table.Column<int>(nullable: true),
                    tips = table.Column<string>(maxLength: 255, nullable: true)
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
                    id = table.Column<int>(nullable: false, comment: "主键")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: true, comment: "创建时间"),
                    create_by = table.Column<int>(nullable: true, comment: "创建者"),
                    modify_time = table.Column<DateTime>(nullable: true, comment: "最后修改时间"),
                    modify_by = table.Column<int>(nullable: true, comment: "最后修改者"),
                    original_file_name = table.Column<string>(maxLength: 255, nullable: true, comment: "实际名称"),
                    real_file_name = table.Column<string>(maxLength: 255, nullable: true, comment: "显示名称")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_file_info", x => x.id);
                },
                comment: "文件信息");

            migrationBuilder.CreateTable(
                name: "sys_login_log",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false, comment: "主键")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: true, comment: "创建时间"),
                    ip = table.Column<string>(maxLength: 255, nullable: true, comment: "登录ip"),
                    logname = table.Column<string>(maxLength: 255, nullable: true, comment: "登陆者姓名"),
                    message = table.Column<string>(maxLength: 255, nullable: true, comment: "消息"),
                    succeed = table.Column<bool>(nullable: false, comment: "是否成功"),
                    userid = table.Column<int>(nullable: true, comment: "用户id")
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
                    id = table.Column<int>(nullable: false, comment: "主键")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: true, comment: "创建时间"),
                    create_by = table.Column<int>(nullable: true, comment: "创建者"),
                    modify_time = table.Column<DateTime>(nullable: true, comment: "最后修改时间"),
                    modify_by = table.Column<int>(nullable: true, comment: "最后修改者"),
                    code = table.Column<string>(maxLength: 32, nullable: false, comment: "菜单编号"),
                    component = table.Column<string>(maxLength: 64, nullable: true, comment: "菜单对应的组件"),
                    hidden = table.Column<bool>(nullable: false, comment: "是否隐藏"),
                    icon = table.Column<string>(maxLength: 32, nullable: true, comment: "图标"),
                    ismenu = table.Column<bool>(nullable: false, comment: "是否是菜单1:菜单,0:按钮"),
                    isopen = table.Column<bool>(nullable: true, comment: "是否默认打开1:是,0:否"),
                    levels = table.Column<int>(nullable: false, comment: "层级"),
                    name = table.Column<string>(maxLength: 64, nullable: false, comment: "名称"),
                    num = table.Column<int>(nullable: false, comment: "顺序"),
                    pcode = table.Column<string>(maxLength: 64, nullable: false, comment: "父菜单编号"),
                    pcodes = table.Column<string>(maxLength: 128, nullable: true, comment: "递归父级菜单编号"),
                    status = table.Column<int>(nullable: false, comment: "状态1:启用,0:禁用"),
                    tips = table.Column<string>(maxLength: 32, nullable: true, comment: "鼠标悬停提示信息"),
                    url = table.Column<string>(maxLength: 32, nullable: true, comment: "链接")
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
                    id = table.Column<int>(nullable: false, comment: "主键")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: true, comment: "创建时间"),
                    create_by = table.Column<int>(nullable: true, comment: "创建者"),
                    modify_time = table.Column<DateTime>(nullable: true, comment: "最后修改时间"),
                    modify_by = table.Column<int>(nullable: true, comment: "最后修改者"),
                    content = table.Column<string>(maxLength: 255, nullable: true, comment: "内容"),
                    title = table.Column<string>(maxLength: 255, nullable: true, comment: "标题"),
                    type = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_notice", x => x.id);
                },
                comment: "欢迎弹窗");

            migrationBuilder.CreateTable(
                name: "sys_operation_log",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false, comment: "主键")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    classname = table.Column<string>(maxLength: 255, nullable: true, comment: "操作类名"),
                    create_time = table.Column<DateTime>(nullable: true, comment: "创建时间"),
                    logname = table.Column<string>(maxLength: 255, nullable: true),
                    logtype = table.Column<string>(maxLength: 255, nullable: true),
                    message = table.Column<string>(nullable: true, comment: "详细信息"),
                    method = table.Column<string>(maxLength: 255, nullable: true, comment: "方法名"),
                    succeed = table.Column<bool>(nullable: false),
                    userid = table.Column<int>(nullable: true)
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
                    id = table.Column<int>(nullable: false, comment: "主键")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    menuid = table.Column<int>(nullable: false),
                    roleid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_relation", x => x.id);
                },
                comment: "角色和菜单的多对多中间表");

            migrationBuilder.CreateTable(
                name: "sys_role",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false, comment: "主键")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: true, comment: "创建时间"),
                    create_by = table.Column<int>(nullable: true, comment: "创建者"),
                    modify_time = table.Column<DateTime>(nullable: true, comment: "最后修改时间"),
                    modify_by = table.Column<int>(nullable: true, comment: "最后修改者"),
                    deptid = table.Column<int>(nullable: true, comment: "部门id"),
                    name = table.Column<string>(maxLength: 255, nullable: true, comment: "角色名"),
                    num = table.Column<int>(nullable: true, comment: "用于排序"),
                    pid = table.Column<int>(nullable: true),
                    tips = table.Column<string>(maxLength: 255, nullable: true),
                    version = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_task",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false, comment: "主键")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: true, comment: "创建时间"),
                    create_by = table.Column<int>(nullable: true, comment: "创建者"),
                    modify_time = table.Column<DateTime>(nullable: true, comment: "最后修改时间"),
                    modify_by = table.Column<int>(nullable: true, comment: "最后修改者"),
                    concurrent = table.Column<bool>(nullable: true, comment: "是否允许并发"),
                    cron = table.Column<string>(maxLength: 50, nullable: true, comment: "corn表达式"),
                    data = table.Column<string>(maxLength: 65535, nullable: true, comment: "执行参数"),
                    disabled = table.Column<bool>(nullable: true, comment: "是否禁用"),
                    exec_at = table.Column<DateTime>(nullable: true, comment: "上次执行时间"),
                    exec_result = table.Column<string>(maxLength: 65535, nullable: true, comment: "执行结果"),
                    job_class = table.Column<string>(maxLength: 255, nullable: true, comment: "执行类"),
                    job_group = table.Column<string>(maxLength: 50, nullable: true, comment: "任务组"),
                    name = table.Column<string>(maxLength: 50, nullable: true, comment: "任务名"),
                    note = table.Column<string>(maxLength: 50, nullable: true, comment: "任务说明")
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
                    id = table.Column<int>(nullable: false, comment: "主键")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    exec_at = table.Column<DateTime>(nullable: true, comment: "执行时间"),
                    exec_success = table.Column<bool>(nullable: true, comment: "是否执行成功"),
                    id_task = table.Column<int>(nullable: true, comment: "任务id"),
                    job_exception = table.Column<string>(maxLength: 500, nullable: true, comment: "异常日志"),
                    name = table.Column<string>(maxLength: 50, nullable: true, comment: "任务名")
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
                    id = table.Column<int>(nullable: false, comment: "主键")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: true, comment: "创建时间"),
                    create_by = table.Column<int>(nullable: true, comment: "创建者"),
                    modify_time = table.Column<DateTime>(nullable: true, comment: "最后修改时间"),
                    modify_by = table.Column<int>(nullable: true, comment: "最后修改者"),
                    account = table.Column<string>(maxLength: 32, nullable: true, comment: "登录账户"),
                    avatar = table.Column<string>(maxLength: 255, nullable: true, comment: "头像"),
                    birthday = table.Column<DateTime>(nullable: true, comment: "生日"),
                    deptid = table.Column<int>(nullable: true, comment: "部门id"),
                    email = table.Column<string>(maxLength: 64, nullable: true, comment: "电子邮箱"),
                    name = table.Column<string>(maxLength: 64, nullable: true, comment: "显示的姓名"),
                    password = table.Column<string>(maxLength: 64, nullable: true, comment: "加密后的密码"),
                    phone = table.Column<string>(maxLength: 16, nullable: true, comment: "联系电话"),
                    roleid = table.Column<string>(maxLength: 128, nullable: true, comment: "角色id列表，以逗号分隔"),
                    salt = table.Column<string>(maxLength: 16, nullable: true, comment: "密码盐"),
                    sex = table.Column<int>(nullable: true, comment: "性别"),
                    status = table.Column<int>(nullable: true, comment: "账户状态"),
                    version = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_user", x => x.id);
                },
                comment: "用户表");

            migrationBuilder.CreateTable(
                name: "message_template",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false, comment: "主键")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    create_time = table.Column<DateTime>(nullable: true, comment: "创建时间"),
                    create_by = table.Column<int>(nullable: true, comment: "创建者"),
                    modify_time = table.Column<DateTime>(nullable: true, comment: "最后修改时间"),
                    modify_by = table.Column<int>(nullable: true, comment: "最后修改者"),
                    code = table.Column<string>(maxLength: 32, nullable: true, comment: "编号"),
                    cond = table.Column<string>(maxLength: 32, nullable: true, comment: "发送条件"),
                    content = table.Column<string>(maxLength: 65535, nullable: true, comment: "内容"),
                    id_message_sender = table.Column<int>(nullable: false, comment: "发送者id"),
                    title = table.Column<string>(maxLength: 64, nullable: true, comment: "标题"),
                    type = table.Column<int>(nullable: false, comment: "消息类型,0:短信,1:邮件")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_message_template", x => x.id);
                    table.ForeignKey(
                        name: "FK_message_template_message_sender_id_message_sender",
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
