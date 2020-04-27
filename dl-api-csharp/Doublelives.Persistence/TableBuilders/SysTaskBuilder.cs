using Doublelives.Domain.Sys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doublelives.Persistence.TableBuilders
{
    public class SysTaskBuilder : IEntityTypeConfiguration<SysTask>
    {
        public void Configure(EntityTypeBuilder<SysTask> builder)
        {
            builder
                .HasComment("定时任务")
                .ToTable("sys_task");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasComment("主键")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.CreateBy)
                .HasComment("创建者")
                .HasColumnName("create_by");

            builder.Property(e => e.CreateTime)
                .HasComment("创建时间")
                .HasColumnName("create_time");

            builder.Property(e => e.ModifyBy)
                .HasComment("最后修改者")
                .HasColumnName("modify_by");

            builder.Property(e => e.ModifyTime)
                .HasComment("最后修改时间")
                .HasColumnName("modify_time");

            builder.Property(e => e.Concurrent)
                .HasComment("是否允许并发")
                .HasColumnName("concurrent");

            builder.Property(e => e.Cron)
                .HasMaxLength(50)
                .HasComment("corn表达式")
                .HasColumnName("cron");

            builder.Property(e => e.Data)
                .HasMaxLength(65535)
                .HasComment("执行参数")
                .HasColumnName("data");

            builder.Property(e => e.Disabled)
                .HasComment("是否禁用")
                .HasColumnName("disabled");

            builder.Property(e => e.ExecAt)
                .HasComment("上次执行时间")
                .HasColumnName("exec_at");

            builder.Property(e => e.ExecResult)
                .HasMaxLength(65535)
                .HasComment("执行结果")
                .HasColumnName("exec_result");

            builder.Property(e => e.JobClass)
                .HasMaxLength(255)
                .HasComment("执行类")
                .HasColumnName("job_class");

            builder.Property(e => e.JobGroup)
                .HasMaxLength(50)
                .HasComment("任务组")
                .HasColumnName("job_group");

            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .HasComment("任务名")
                .HasColumnName("name");

            builder.Property(e => e.Note)
                .HasMaxLength(50)
                .HasComment("任务说明")
                .HasColumnName("note");
        }
    }
}
