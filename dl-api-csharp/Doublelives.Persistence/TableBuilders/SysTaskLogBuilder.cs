using Doublelives.Domain.Sys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doublelives.Persistence.TableBuilders
{
    public class SysTaskLogBuilder : IEntityTypeConfiguration<SysTaskLog>
    {
        public void Configure(EntityTypeBuilder<SysTaskLog> builder)
        {
            builder
                .HasComment("定时任务日志")
                .ToTable("sys_task_log");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasComment("主键")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.ExecAt)
                .HasComment("执行时间")
                .HasColumnName("exec_at");

            builder.Property(e => e.ExecSuccess)
                .HasComment("是否执行成功")
                .HasColumnName("exec_success");

            builder.Property(e => e.IdTask)
                .HasComment("任务id")
                .HasColumnName("id_task");

            builder.Property(e => e.JobException)
                .HasMaxLength(500)
                .HasComment("异常日志")
                .HasColumnName("job_exception");

            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .HasComment("任务名")
                .HasColumnName("name");
        }
    }
}