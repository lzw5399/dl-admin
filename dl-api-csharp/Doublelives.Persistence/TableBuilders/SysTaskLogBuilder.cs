using Doublelives.Domain.Sys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doublelives.Persistence.TableBuilders
{
    public class SysTaskLogBuilder : IEntityTypeConfiguration<SysTaskLog>
    {
        public void Configure(EntityTypeBuilder<SysTaskLog> builder)
        {
            builder.ToTable("sys_task_log");

            builder.HasComment("定时任务日志");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("INTEGER");

            builder.Property(e => e.ExecAt)
                .HasColumnName("exec_at")
                .HasColumnType("datetime")
                .HasComment("执行时间");

            builder.Property(e => e.ExecSuccess)
                .HasColumnName("exec_success")
                .HasColumnType("INTEGER")
                .HasComment("执行结果（成功:1、失败:0)");

            builder.Property(e => e.IdTask)
                .HasColumnName("id_task")
                .HasColumnType("INTEGER");

            builder.Property(e => e.JobException)
                .HasColumnName("job_exception")
                .HasColumnType("varchar(500)")
                .HasComment("抛出异常")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(50)")
                .HasComment("任务名")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");
        }
    }
}
