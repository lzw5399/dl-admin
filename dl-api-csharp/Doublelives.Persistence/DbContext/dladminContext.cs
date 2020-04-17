using System;
using Doublelives.Domain.Cms;
using Doublelives.Domain.Messages;
using Doublelives.Domain.Sys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Doublelives.Migrations.DbFirstProcess
{
    public class dladminContext : DbContext
    {
        public dladminContext()
        {
        }

        public dladminContext(DbContextOptions<dladminContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CmsArticle> CmsArticle { get; set; }
        public virtual DbSet<CmsBanner> CmsBanner { get; set; }
        public virtual DbSet<CmsChannel> CmsChannel { get; set; }
        public virtual DbSet<CmsContacts> CmsContacts { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<MessageSender> MessageSender { get; set; }
        public virtual DbSet<MessageTemplate> MessageTemplate { get; set; }
        public virtual DbSet<SysCfg> SysCfg { get; set; }
        public virtual DbSet<SysDept> SysDept { get; set; }
        public virtual DbSet<SysDict> SysDict { get; set; }
        public virtual DbSet<SysFileInfo> SysFileInfo { get; set; }
        public virtual DbSet<SysLoginLog> SysLoginLog { get; set; }
        public virtual DbSet<SysMenu> SysMenu { get; set; }
        public virtual DbSet<SysNotice> SysNotice { get; set; }
        public virtual DbSet<SysOperationLog> SysOperationLog { get; set; }
        public virtual DbSet<SysRelation> SysRelation { get; set; }
        public virtual DbSet<SysRole> SysRole { get; set; }
        public virtual DbSet<SysTask> SysTask { get; set; }
        public virtual DbSet<SysTaskLog> SysTaskLog { get; set; }
        public virtual DbSet<SysUser> SysUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CmsArticle>(entity =>
            {
                entity.ToTable("cms_article");

                entity.HasComment("文章");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Author)
                    .HasColumnName("author")
                    .HasColumnType("varchar(64)")
                    .HasComment("作者")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("text")
                    .HasComment("内容")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasColumnType("bigint(20)")
                    .HasComment("创建人");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime")
                    .HasComment("创建时间/注册时间");

                entity.Property(e => e.IdChannel)
                    .HasColumnName("id_channel")
                    .HasColumnType("bigint(20)")
                    .HasComment("栏目id");

                entity.Property(e => e.Img)
                    .HasColumnName("img")
                    .HasColumnType("varchar(64)")
                    .HasComment("文章题图ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ModifyBy)
                    .HasColumnName("modify_by")
                    .HasColumnType("bigint(20)")
                    .HasComment("最后更新人");

                entity.Property(e => e.ModifyTime)
                    .HasColumnName("modify_time")
                    .HasColumnType("datetime")
                    .HasComment("最后更新时间");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(128)")
                    .HasComment("标题")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<CmsBanner>(entity =>
            {
                entity.ToTable("cms_banner");

                entity.HasComment("Banner");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasColumnType("bigint(20)")
                    .HasComment("创建人");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime")
                    .HasComment("创建时间/注册时间");

                entity.Property(e => e.IdFile)
                    .HasColumnName("id_file")
                    .HasColumnType("bigint(20)")
                    .HasComment("banner图id");

                entity.Property(e => e.ModifyBy)
                    .HasColumnName("modify_by")
                    .HasColumnType("bigint(20)")
                    .HasComment("最后更新人");

                entity.Property(e => e.ModifyTime)
                    .HasColumnName("modify_time")
                    .HasColumnType("datetime")
                    .HasComment("最后更新时间");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(64)")
                    .HasComment("标题")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("varchar(32)")
                    .HasComment("类型")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasColumnType("varchar(128)")
                    .HasComment("点击banner跳转到url")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<CmsChannel>(entity =>
            {
                entity.ToTable("cms_channel");

                entity.HasComment("文章栏目");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("varchar(64)")
                    .HasComment("编码")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasColumnType("bigint(20)")
                    .HasComment("创建人");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime")
                    .HasComment("创建时间/注册时间");

                entity.Property(e => e.ModifyBy)
                    .HasColumnName("modify_by")
                    .HasColumnType("bigint(20)")
                    .HasComment("最后更新人");

                entity.Property(e => e.ModifyTime)
                    .HasColumnName("modify_time")
                    .HasColumnType("datetime")
                    .HasComment("最后更新时间");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(64)")
                    .HasComment("名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<CmsContacts>(entity =>
            {
                entity.ToTable("cms_contacts");

                entity.HasComment("邀约信息");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasColumnType("bigint(20)")
                    .HasComment("创建人");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime")
                    .HasComment("创建时间/注册时间");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(32)")
                    .HasComment("电子邮箱")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Mobile)
                    .HasColumnName("mobile")
                    .HasColumnType("varchar(64)")
                    .HasComment("联系电话")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ModifyBy)
                    .HasColumnName("modify_by")
                    .HasColumnType("bigint(20)")
                    .HasComment("最后更新人");

                entity.Property(e => e.ModifyTime)
                    .HasColumnName("modify_time")
                    .HasColumnType("datetime")
                    .HasComment("最后更新时间");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasColumnType("varchar(128)")
                    .HasComment("备注")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserName)
                    .HasColumnName("user_name")
                    .HasColumnType("varchar(64)")
                    .HasComment("邀约人名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("message");

                entity.HasComment("历史消息");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("text")
                    .HasComment("消息内容")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasColumnType("bigint(20)")
                    .HasComment("创建人");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime")
                    .HasComment("创建时间/注册时间");

                entity.Property(e => e.ModifyBy)
                    .HasColumnName("modify_by")
                    .HasColumnType("bigint(20)")
                    .HasComment("最后更新人");

                entity.Property(e => e.ModifyTime)
                    .HasColumnName("modify_time")
                    .HasColumnType("datetime")
                    .HasComment("最后更新时间");

                entity.Property(e => e.Receiver)
                    .HasColumnName("receiver")
                    .HasColumnType("varchar(64)")
                    .HasComment("接收者")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("varchar(32)")
                    .HasComment("消息类型,0:初始,1:成功,2:失败")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TplCode)
                    .HasColumnName("tpl_code")
                    .HasColumnType("varchar(32)")
                    .HasComment("模板编码")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("varchar(32)")
                    .HasComment("消息类型,0:短信,1:邮件")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<MessageSender>(entity =>
            {
                entity.ToTable("message_sender");

                entity.HasComment("消息发送者");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ClassName)
                    .HasColumnName("class_name")
                    .HasColumnType("varchar(64)")
                    .HasComment("发送类")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasColumnType("bigint(20)")
                    .HasComment("创建人");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime")
                    .HasComment("创建时间/注册时间");

                entity.Property(e => e.ModifyBy)
                    .HasColumnName("modify_by")
                    .HasColumnType("bigint(20)")
                    .HasComment("最后更新人");

                entity.Property(e => e.ModifyTime)
                    .HasColumnName("modify_time")
                    .HasColumnType("datetime")
                    .HasComment("最后更新时间");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(64)")
                    .HasComment("名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TplCode)
                    .HasColumnName("tpl_code")
                    .HasColumnType("varchar(64)")
                    .HasComment("短信运营商模板编号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<MessageTemplate>(entity =>
            {
                entity.ToTable("message_template");

                entity.HasComment("消息模板");

                entity.HasIndex(e => e.IdMessageSender)
                    .HasName("FK942sadqk5x9kbrwil0psyek3n");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("varchar(32)")
                    .HasComment("编号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Cond)
                    .HasColumnName("cond")
                    .HasColumnType("varchar(32)")
                    .HasComment("发送条件")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("text")
                    .HasComment("内容")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasColumnType("bigint(20)")
                    .HasComment("创建人");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime")
                    .HasComment("创建时间/注册时间");

                entity.Property(e => e.IdMessageSender)
                    .HasColumnName("id_message_sender")
                    .HasColumnType("bigint(20)")
                    .HasComment("发送者id");

                entity.Property(e => e.ModifyBy)
                    .HasColumnName("modify_by")
                    .HasColumnType("bigint(20)")
                    .HasComment("最后更新人");

                entity.Property(e => e.ModifyTime)
                    .HasColumnName("modify_time")
                    .HasColumnType("datetime")
                    .HasComment("最后更新时间");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(64)")
                    .HasComment("标题")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("varchar(32)")
                    .HasComment("消息类型,0:短信,1:邮件")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdMessageSenderNavigation)
                    .WithMany(p => p.MessageTemplate)
                    .HasForeignKey(d => d.IdMessageSender)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK942sadqk5x9kbrwil0psyek3n");
            });

            modelBuilder.Entity<SysCfg>(entity =>
            {
                entity.ToTable("sys_cfg");

                entity.HasComment("系统参数");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CfgDesc)
                    .HasColumnName("cfg_desc")
                    .HasColumnType("text")
                    .HasComment("备注")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CfgName)
                    .HasColumnName("cfg_name")
                    .HasColumnType("varchar(256)")
                    .HasComment("参数名")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CfgValue)
                    .HasColumnName("cfg_value")
                    .HasColumnType("varchar(512)")
                    .HasComment("参数值")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasColumnType("bigint(20)")
                    .HasComment("创建人");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime")
                    .HasComment("创建时间/注册时间");

                entity.Property(e => e.ModifyBy)
                    .HasColumnName("modify_by")
                    .HasColumnType("bigint(20)")
                    .HasComment("最后更新人");

                entity.Property(e => e.ModifyTime)
                    .HasColumnName("modify_time")
                    .HasColumnType("datetime")
                    .HasComment("最后更新时间");
            });

            modelBuilder.Entity<SysDept>(entity =>
            {
                entity.ToTable("sys_dept");

                entity.HasComment("部门");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasColumnType("bigint(20)")
                    .HasComment("创建人");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime")
                    .HasComment("创建时间/注册时间");

                entity.Property(e => e.Fullname)
                    .HasColumnName("fullname")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ModifyBy)
                    .HasColumnName("modify_by")
                    .HasColumnType("bigint(20)")
                    .HasComment("最后更新人");

                entity.Property(e => e.ModifyTime)
                    .HasColumnName("modify_time")
                    .HasColumnType("datetime")
                    .HasComment("最后更新时间");

                entity.Property(e => e.Num)
                    .HasColumnName("num")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Pid)
                    .HasColumnName("pid")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Pids)
                    .HasColumnName("pids")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Simplename)
                    .HasColumnName("simplename")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Tips)
                    .HasColumnName("tips")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<SysDict>(entity =>
            {
                entity.ToTable("sys_dict");

                entity.HasComment("字典");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasColumnType("bigint(20)")
                    .HasComment("创建人");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime")
                    .HasComment("创建时间/注册时间");

                entity.Property(e => e.ModifyBy)
                    .HasColumnName("modify_by")
                    .HasColumnType("bigint(20)")
                    .HasComment("最后更新人");

                entity.Property(e => e.ModifyTime)
                    .HasColumnName("modify_time")
                    .HasColumnType("datetime")
                    .HasComment("最后更新时间");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Num)
                    .HasColumnName("num")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Pid)
                    .HasColumnName("pid")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Tips)
                    .HasColumnName("tips")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<SysFileInfo>(entity =>
            {
                entity.ToTable("sys_file_info");

                entity.HasComment("文件");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasColumnType("bigint(20)")
                    .HasComment("创建人");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime")
                    .HasComment("创建时间/注册时间");

                entity.Property(e => e.ModifyBy)
                    .HasColumnName("modify_by")
                    .HasColumnType("bigint(20)")
                    .HasComment("最后更新人");

                entity.Property(e => e.ModifyTime)
                    .HasColumnName("modify_time")
                    .HasColumnType("datetime")
                    .HasComment("最后更新时间");

                entity.Property(e => e.OriginalFileName)
                    .HasColumnName("original_file_name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RealFileName)
                    .HasColumnName("real_file_name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<SysLoginLog>(entity =>
            {
                entity.ToTable("sys_login_log");

                entity.HasComment("登录日志");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.Ip)
                    .HasColumnName("ip")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Logname)
                    .HasColumnName("logname")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Succeed)
                    .HasColumnName("succeed")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<SysMenu>(entity =>
            {
                entity.ToTable("sys_menu");

                entity.HasComment("菜单");

                entity.HasIndex(e => e.Code)
                    .HasName("UK_s37unj3gh67ujhk83lqva8i1t")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasColumnType("varchar(32)")
                    .HasComment("编号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Component)
                    .HasColumnName("component")
                    .HasColumnType("varchar(64)")
                    .HasComment("页面组件")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasColumnType("bigint(20)")
                    .HasComment("创建人");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime")
                    .HasComment("创建时间/注册时间");

                entity.Property(e => e.Hidden)
                    .HasColumnName("hidden")
                    .HasColumnType("tinyint(4)")
                    .HasComment("是否隐藏");

                entity.Property(e => e.Icon)
                    .HasColumnName("icon")
                    .HasColumnType("varchar(32)")
                    .HasComment("图标")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Ismenu)
                    .HasColumnName("ismenu")
                    .HasColumnType("int(11)")
                    .HasComment("是否是菜单1:菜单,0:按钮");

                entity.Property(e => e.Isopen)
                    .HasColumnName("isopen")
                    .HasColumnType("int(11)")
                    .HasComment("是否默认打开1:是,0:否");

                entity.Property(e => e.Levels)
                    .HasColumnName("levels")
                    .HasColumnType("int(11)")
                    .HasComment("级别");

                entity.Property(e => e.ModifyBy)
                    .HasColumnName("modify_by")
                    .HasColumnType("bigint(20)")
                    .HasComment("最后更新人");

                entity.Property(e => e.ModifyTime)
                    .HasColumnName("modify_time")
                    .HasColumnType("datetime")
                    .HasComment("最后更新时间");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(64)")
                    .HasComment("名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Num)
                    .HasColumnName("num")
                    .HasColumnType("int(11)")
                    .HasComment("顺序");

                entity.Property(e => e.Pcode)
                    .IsRequired()
                    .HasColumnName("pcode")
                    .HasColumnType("varchar(64)")
                    .HasComment("父菜单编号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Pcodes)
                    .HasColumnName("pcodes")
                    .HasColumnType("varchar(128)")
                    .HasComment("递归父级菜单编号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)")
                    .HasComment("状态1:启用,0:禁用");

                entity.Property(e => e.Tips)
                    .HasColumnName("tips")
                    .HasColumnType("varchar(32)")
                    .HasComment("鼠标悬停提示信息")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasColumnType("varchar(32)")
                    .HasComment("链接标识")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<SysNotice>(entity =>
            {
                entity.ToTable("sys_notice");

                entity.HasComment("通知");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasColumnType("bigint(20)")
                    .HasComment("创建人");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime")
                    .HasComment("创建时间/注册时间");

                entity.Property(e => e.ModifyBy)
                    .HasColumnName("modify_by")
                    .HasColumnType("bigint(20)")
                    .HasComment("最后更新人");

                entity.Property(e => e.ModifyTime)
                    .HasColumnName("modify_time")
                    .HasColumnType("datetime")
                    .HasComment("最后更新时间");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<SysOperationLog>(entity =>
            {
                entity.ToTable("sys_operation_log");

                entity.HasComment("操作日志");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Classname)
                    .HasColumnName("classname")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Logname)
                    .HasColumnName("logname")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Logtype)
                    .HasColumnName("logtype")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasColumnType("text")
                    .HasComment("详细信息")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Method)
                    .HasColumnName("method")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Succeed)
                    .HasColumnName("succeed")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<SysRelation>(entity =>
            {
                entity.ToTable("sys_relation");

                entity.HasComment("菜单角色关系");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Menuid)
                    .HasColumnName("menuid")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Roleid)
                    .HasColumnName("roleid")
                    .HasColumnType("bigint(20)");
            });

            modelBuilder.Entity<SysRole>(entity =>
            {
                entity.ToTable("sys_role");

                entity.HasComment("角色");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasColumnType("bigint(20)")
                    .HasComment("创建人");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime")
                    .HasComment("创建时间/注册时间");

                entity.Property(e => e.Deptid)
                    .HasColumnName("deptid")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ModifyBy)
                    .HasColumnName("modify_by")
                    .HasColumnType("bigint(20)")
                    .HasComment("最后更新人");

                entity.Property(e => e.ModifyTime)
                    .HasColumnName("modify_time")
                    .HasColumnType("datetime")
                    .HasComment("最后更新时间");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Num)
                    .HasColumnName("num")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Pid)
                    .HasColumnName("pid")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Tips)
                    .HasColumnName("tips")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<SysTask>(entity =>
            {
                entity.ToTable("sys_task");

                entity.HasComment("定时任务");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Concurrent)
                    .HasColumnName("concurrent")
                    .HasColumnType("tinyint(4)")
                    .HasComment("是否允许并发");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasColumnType("bigint(20)")
                    .HasComment("创建人");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime")
                    .HasComment("创建时间/注册时间");

                entity.Property(e => e.Cron)
                    .HasColumnName("cron")
                    .HasColumnType("varchar(50)")
                    .HasComment("定时规则")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("text")
                    .HasComment("执行参数")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Disabled)
                    .HasColumnName("disabled")
                    .HasColumnType("tinyint(4)")
                    .HasComment("是否禁用");

                entity.Property(e => e.ExecAt)
                    .HasColumnName("exec_at")
                    .HasColumnType("datetime")
                    .HasComment("执行时间");

                entity.Property(e => e.ExecResult)
                    .HasColumnName("exec_result")
                    .HasColumnType("text")
                    .HasComment("执行结果")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.JobClass)
                    .HasColumnName("job_class")
                    .HasColumnType("varchar(255)")
                    .HasComment("执行类")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.JobGroup)
                    .HasColumnName("job_group")
                    .HasColumnType("varchar(50)")
                    .HasComment("任务组名")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ModifyBy)
                    .HasColumnName("modify_by")
                    .HasColumnType("bigint(20)")
                    .HasComment("最后更新人");

                entity.Property(e => e.ModifyTime)
                    .HasColumnName("modify_time")
                    .HasColumnType("datetime")
                    .HasComment("最后更新时间");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasComment("任务名")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("varchar(255)")
                    .HasComment("任务说明")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<SysTaskLog>(entity =>
            {
                entity.ToTable("sys_task_log");

                entity.HasComment("定时任务日志");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ExecAt)
                    .HasColumnName("exec_at")
                    .HasColumnType("datetime")
                    .HasComment("执行时间");

                entity.Property(e => e.ExecSuccess)
                    .HasColumnName("exec_success")
                    .HasColumnType("int(11)")
                    .HasComment("执行结果（成功:1、失败:0)");

                entity.Property(e => e.IdTask)
                    .HasColumnName("id_task")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.JobException)
                    .HasColumnName("job_exception")
                    .HasColumnType("varchar(500)")
                    .HasComment("抛出异常")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasComment("任务名")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<SysUser>(entity =>
            {
                entity.ToTable("sys_user");

                entity.HasComment("账号");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Account)
                    .HasColumnName("account")
                    .HasColumnType("varchar(32)")
                    .HasComment("账户")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Avatar)
                    .HasColumnName("avatar")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by")
                    .HasColumnType("bigint(20)")
                    .HasComment("创建人");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime")
                    .HasComment("创建时间/注册时间");

                entity.Property(e => e.Deptid)
                    .HasColumnName("deptid")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(64)")
                    .HasComment("email")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ModifyBy)
                    .HasColumnName("modify_by")
                    .HasColumnType("bigint(20)")
                    .HasComment("最后更新人");

                entity.Property(e => e.ModifyTime)
                    .HasColumnName("modify_time")
                    .HasColumnType("datetime")
                    .HasComment("最后更新时间");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(64)")
                    .HasComment("姓名")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(64)")
                    .HasComment("密码")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasColumnType("varchar(16)")
                    .HasComment("手机号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Roleid)
                    .HasColumnName("roleid")
                    .HasColumnType("varchar(128)")
                    .HasComment("角色id列表，以逗号分隔")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Salt)
                    .HasColumnName("salt")
                    .HasColumnType("varchar(16)")
                    .HasComment("密码盐")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasColumnType("int(11)");
            });

        }
    }
}
