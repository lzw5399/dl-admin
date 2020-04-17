using System;
using Doublelives.Domain.Cms;
using Doublelives.Domain.Messages;
using Doublelives.Domain.Sys;
using Doublelives.Persistence.TableBuilders;
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
            modelBuilder.ApplyConfiguration(new CmsArticleBuilder());
            modelBuilder.ApplyConfiguration(new CmsBannerBuilder());
            modelBuilder.ApplyConfiguration(new CmsChannelBuilder());
            modelBuilder.ApplyConfiguration(new CmsContactsBuilder());
            modelBuilder.ApplyConfiguration(new MessageBuilder());
            modelBuilder.ApplyConfiguration(new MessageSenderBuilder());
            modelBuilder.ApplyConfiguration(new MessageTemplateBuilder());
            modelBuilder.ApplyConfiguration(new SysCfgBuilder());
            modelBuilder.ApplyConfiguration(new SysDeptBuilder());
            modelBuilder.ApplyConfiguration(new SysDictBuilder());
            modelBuilder.ApplyConfiguration(new SysFileInfoBuilder());
            modelBuilder.ApplyConfiguration(new SysLoginLogBuilder());
            modelBuilder.ApplyConfiguration(new SysMenuBuilder());
            modelBuilder.ApplyConfiguration(new SysNoticeBuilder());
            modelBuilder.ApplyConfiguration(new SysOperationLogBuilder());
            modelBuilder.ApplyConfiguration(new SysRelationBuilder());
            modelBuilder.ApplyConfiguration(new SysRoleBuilder());
            modelBuilder.ApplyConfiguration(new SysTaskBuilder());
            modelBuilder.ApplyConfiguration(new SysTaskLogBuilder());
            modelBuilder.ApplyConfiguration(new SysUserBuilder());

            base.OnModelCreating(modelBuilder);
        }
    }
}
