using Doublelives.Domain.Sys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doublelives.Persistence.TableBuilders
{
    public class SysTaskBuilder : IEntityTypeConfiguration<SysTask>
    {
        public void Configure(EntityTypeBuilder<SysTask> builder)
        {
            builder.ToTable("sys_task");

            builder.HasComment("定时任务");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("bigint(20)");

            builder.Property(e => e.Concurrent)
                .HasColumnName("concurrent")
                .HasColumnType("tinyint(4)")
                .HasComment("是否允许并发");

            builder.Property(e => e.CreateBy)
                .HasColumnName("create_by")
                .HasColumnType("bigint(20)")
                .HasComment("创建人");

            builder.Property(e => e.CreateTime)
                .HasColumnName("create_time")
                .HasColumnType("datetime")
                .HasComment("创建时间/注册时间");

            builder.Property(e => e.Cron)
                .HasColumnName("cron")
                .HasColumnType("varchar(50)")
                .HasComment("定时规则")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.Data)
                .HasColumnName("data")
                .HasColumnType("text")
                .HasComment("执行参数")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.Disabled)
                .HasColumnName("disabled")
                .HasColumnType("tinyint(4)")
                .HasComment("是否禁用");

            builder.Property(e => e.ExecAt)
                .HasColumnName("exec_at")
                .HasColumnType("datetime")
                .HasComment("执行时间");

            builder.Property(e => e.ExecResult)
                .HasColumnName("exec_result")
                .HasColumnType("text")
                .HasComment("执行结果")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.JobClass)
                .HasColumnName("job_class")
                .HasColumnType("varchar(255)")
                .HasComment("执行类")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.JobGroup)
                .HasColumnName("job_group")
                .HasColumnType("varchar(50)")
                .HasComment("任务组名")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.ModifyBy)
                .HasColumnName("modify_by")
                .HasColumnType("bigint(20)")
                .HasComment("最后更新人");

            builder.Property(e => e.ModifyTime)
                .HasColumnName("modify_time")
                .HasColumnType("datetime")
                .HasComment("最后更新时间");

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(50)")
                .HasComment("任务名")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.Note)
                .HasColumnName("note")
                .HasColumnType("varchar(255)")
                .HasComment("任务说明")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");
        }
    }
}
