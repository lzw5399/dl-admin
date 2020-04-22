using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Doublelives.Migrations.Migrations
{
    public partial class optimizedstruct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cms_article",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    create_time = table.Column<DateTime>(nullable: true),
                    create_by = table.Column<int>(nullable: true),
                    modify_time = table.Column<DateTime>(nullable: true),
                    modify_by = table.Column<int>(nullable: true),
                    author = table.Column<string>(type: "text(64)", nullable: true),
                    content = table.Column<string>(nullable: true),
                    id_channel = table.Column<int>(nullable: false),
                    img = table.Column<string>(type: "text(64)", nullable: true),
                    title = table.Column<string>(type: "text(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_article", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cms_banner",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    create_time = table.Column<DateTime>(nullable: true),
                    create_by = table.Column<int>(nullable: true),
                    modify_time = table.Column<DateTime>(nullable: true),
                    modify_by = table.Column<int>(nullable: true),
                    id_file = table.Column<int>(nullable: true),
                    title = table.Column<string>(type: "text(64)", nullable: true),
                    type = table.Column<string>(type: "text(32)", nullable: true),
                    url = table.Column<string>(type: "text(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_banner", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cms_channel",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    create_time = table.Column<DateTime>(nullable: true),
                    create_by = table.Column<int>(nullable: true),
                    modify_time = table.Column<DateTime>(nullable: true),
                    modify_by = table.Column<int>(nullable: true),
                    code = table.Column<string>(type: "text(64)", nullable: true),
                    name = table.Column<string>(type: "text(64)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_channel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cms_contacts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    create_time = table.Column<DateTime>(nullable: true),
                    create_by = table.Column<int>(nullable: true),
                    modify_time = table.Column<DateTime>(nullable: true),
                    modify_by = table.Column<int>(nullable: true),
                    email = table.Column<string>(type: "text(32)", nullable: true),
                    mobile = table.Column<string>(type: "text(64)", nullable: true),
                    remark = table.Column<string>(type: "text(128)", nullable: true),
                    user_name = table.Column<string>(type: "text(64)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_contacts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "message",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    create_time = table.Column<DateTime>(nullable: true),
                    create_by = table.Column<int>(nullable: true),
                    modify_time = table.Column<DateTime>(nullable: true),
                    modify_by = table.Column<int>(nullable: true),
                    content = table.Column<string>(nullable: true),
                    receiver = table.Column<string>(type: "text(64)", nullable: true),
                    state = table.Column<string>(type: "text(32)", nullable: true),
                    tpl_code = table.Column<string>(type: "text(32)", nullable: true),
                    type = table.Column<string>(type: "text(32)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_message", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "message_sender",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    create_time = table.Column<DateTime>(nullable: true),
                    create_by = table.Column<int>(nullable: true),
                    modify_time = table.Column<DateTime>(nullable: true),
                    modify_by = table.Column<int>(nullable: true),
                    class_name = table.Column<string>(type: "text(64)", nullable: true),
                    name = table.Column<string>(type: "text(64)", nullable: true),
                    tpl_code = table.Column<string>(type: "text(64)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_message_sender", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_cfg",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    create_time = table.Column<DateTime>(nullable: true),
                    create_by = table.Column<int>(nullable: true),
                    modify_time = table.Column<DateTime>(nullable: true),
                    modify_by = table.Column<int>(nullable: true),
                    cfg_desc = table.Column<string>(nullable: true),
                    cfg_name = table.Column<string>(type: "text(256)", nullable: true),
                    cfg_value = table.Column<string>(type: "text(512)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_cfg", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_dept",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    create_time = table.Column<DateTime>(nullable: true),
                    create_by = table.Column<int>(nullable: true),
                    modify_time = table.Column<DateTime>(nullable: true),
                    modify_by = table.Column<int>(nullable: true),
                    fullname = table.Column<string>(type: "text(255)", nullable: true),
                    num = table.Column<int>(nullable: true),
                    pid = table.Column<int>(nullable: true),
                    pids = table.Column<string>(type: "text(255)", nullable: true),
                    simplename = table.Column<string>(type: "text(255)", nullable: true),
                    tips = table.Column<string>(type: "text(255)", nullable: true),
                    version = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_dept", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_dict",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    create_time = table.Column<DateTime>(nullable: true),
                    create_by = table.Column<int>(nullable: true),
                    modify_time = table.Column<DateTime>(nullable: true),
                    modify_by = table.Column<int>(nullable: true),
                    name = table.Column<string>(type: "text(255)", nullable: true),
                    num = table.Column<string>(type: "text(255)", nullable: true),
                    pid = table.Column<int>(nullable: true),
                    tips = table.Column<string>(type: "text(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_dict", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_file_info",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    create_time = table.Column<DateTime>(nullable: true),
                    create_by = table.Column<int>(nullable: true),
                    modify_time = table.Column<DateTime>(nullable: true),
                    modify_by = table.Column<int>(nullable: true),
                    original_file_name = table.Column<string>(type: "text(255)", nullable: true),
                    real_file_name = table.Column<string>(type: "text(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_file_info", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_login_log",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    create_time = table.Column<DateTime>(nullable: true),
                    ip = table.Column<string>(type: "text(255)", nullable: true),
                    logname = table.Column<string>(type: "text(255)", nullable: true),
                    message = table.Column<string>(type: "text(255)", nullable: true),
                    succeed = table.Column<string>(type: "text(255)", nullable: true),
                    userid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_login_log", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_menu",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    create_time = table.Column<DateTime>(nullable: true),
                    create_by = table.Column<int>(nullable: true),
                    modify_time = table.Column<DateTime>(nullable: true),
                    modify_by = table.Column<int>(nullable: true),
                    code = table.Column<string>(type: "text(32)", nullable: false),
                    component = table.Column<string>(type: "text(64)", nullable: true),
                    hidden = table.Column<bool>(nullable: false),
                    icon = table.Column<string>(type: "text(32)", nullable: true),
                    ismenu = table.Column<bool>(nullable: false),
                    isopen = table.Column<bool>(nullable: true),
                    levels = table.Column<int>(nullable: false),
                    name = table.Column<string>(type: "text(64)", nullable: false),
                    num = table.Column<int>(nullable: false),
                    pcode = table.Column<string>(type: "text(64)", nullable: false),
                    pcodes = table.Column<string>(type: "text(128)", nullable: true),
                    status = table.Column<int>(nullable: false),
                    tips = table.Column<string>(type: "text(32)", nullable: true),
                    url = table.Column<string>(type: "text(32)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_menu", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_notice",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    create_time = table.Column<DateTime>(nullable: true),
                    create_by = table.Column<int>(nullable: true),
                    modify_time = table.Column<DateTime>(nullable: true),
                    modify_by = table.Column<int>(nullable: true),
                    content = table.Column<string>(type: "text(255)", nullable: true),
                    title = table.Column<string>(type: "text(255)", nullable: true),
                    type = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_notice", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_operation_log",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    classname = table.Column<string>(type: "text(255)", nullable: true),
                    create_time = table.Column<DateTime>(nullable: true),
                    logname = table.Column<string>(type: "text(255)", nullable: true),
                    logtype = table.Column<string>(type: "text(255)", nullable: true),
                    message = table.Column<string>(nullable: true),
                    method = table.Column<string>(type: "text(255)", nullable: true),
                    succeed = table.Column<string>(type: "text(255)", nullable: true),
                    userid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_operation_log", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_relation",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    menuid = table.Column<int>(nullable: false),
                    roleid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_relation", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_role",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    create_time = table.Column<DateTime>(nullable: true),
                    create_by = table.Column<int>(nullable: true),
                    modify_time = table.Column<DateTime>(nullable: true),
                    modify_by = table.Column<int>(nullable: true),
                    deptid = table.Column<int>(nullable: true),
                    name = table.Column<string>(type: "text(255)", nullable: true),
                    num = table.Column<int>(nullable: true),
                    pid = table.Column<int>(nullable: true),
                    tips = table.Column<string>(type: "text(255)", nullable: true),
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
                    id = table.Column<int>(nullable: false),
                    create_time = table.Column<DateTime>(nullable: true),
                    create_by = table.Column<int>(nullable: true),
                    modify_time = table.Column<DateTime>(nullable: true),
                    modify_by = table.Column<int>(nullable: true),
                    concurrent = table.Column<bool>(nullable: true),
                    cron = table.Column<string>(type: "text(50)", nullable: true),
                    data = table.Column<string>(nullable: true),
                    disabled = table.Column<bool>(nullable: true),
                    exec_at = table.Column<DateTime>(nullable: true),
                    exec_result = table.Column<string>(nullable: true),
                    job_class = table.Column<string>(type: "text(255)", nullable: true),
                    job_group = table.Column<string>(type: "text(50)", nullable: true),
                    name = table.Column<string>(type: "text(50)", nullable: true),
                    note = table.Column<string>(type: "text(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_task", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_task_log",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    exec_at = table.Column<DateTime>(nullable: true),
                    exec_success = table.Column<bool>(nullable: true),
                    id_task = table.Column<int>(nullable: true),
                    job_exception = table.Column<string>(type: "text(500)", nullable: true),
                    name = table.Column<string>(type: "text(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_task_log", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_user",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    create_time = table.Column<DateTime>(nullable: true),
                    create_by = table.Column<int>(nullable: true),
                    modify_time = table.Column<DateTime>(nullable: true),
                    modify_by = table.Column<int>(nullable: true),
                    account = table.Column<string>(type: "text(32)", nullable: true),
                    avatar = table.Column<string>(type: "text(255)", nullable: true),
                    birthday = table.Column<DateTime>(nullable: true),
                    deptid = table.Column<int>(nullable: true),
                    email = table.Column<string>(type: "text(64)", nullable: true),
                    name = table.Column<string>(type: "text(64)", nullable: true),
                    password = table.Column<string>(type: "text(64)", nullable: true),
                    phone = table.Column<string>(type: "text(16)", nullable: true),
                    roleid = table.Column<string>(type: "text(128)", nullable: true),
                    salt = table.Column<string>(type: "text(16)", nullable: true),
                    sex = table.Column<int>(nullable: true),
                    status = table.Column<int>(nullable: true),
                    version = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "message_template",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    create_time = table.Column<DateTime>(nullable: true),
                    create_by = table.Column<int>(nullable: true),
                    modify_time = table.Column<DateTime>(nullable: true),
                    modify_by = table.Column<int>(nullable: true),
                    code = table.Column<string>(type: "text(32)", nullable: true),
                    cond = table.Column<string>(type: "text(32)", nullable: true),
                    content = table.Column<string>(nullable: true),
                    id_message_sender = table.Column<int>(nullable: false),
                    title = table.Column<string>(type: "text(64)", nullable: true),
                    type = table.Column<string>(type: "text(32)", nullable: true)
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
                });

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
