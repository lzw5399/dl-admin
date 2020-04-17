using Doublelives.Domain.Infrastructure;
using Doublelives.Persistence.TableBuilders;
using Microsoft.EntityFrameworkCore;

namespace Doublelives.Persistence
{
    public class DlAdminDbContext : DbContext
    {
        public DlAdminDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : EntityBase
        {
            return base.Set<TEntity>();
        }

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
