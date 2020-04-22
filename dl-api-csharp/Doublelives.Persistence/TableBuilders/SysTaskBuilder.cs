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

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(e => e.Concurrent).HasColumnName("concurrent");

            builder.Property(e => e.CreateBy).HasColumnName("create_by");

            builder.Property(e => e.CreateTime).HasColumnName("create_time");

            builder.Property(e => e.Cron)
                .HasColumnName("cron")
                .HasColumnType("text(50)");

            builder.Property(e => e.Data).HasColumnName("data");

            builder.Property(e => e.Disabled).HasColumnName("disabled");

            builder.Property(e => e.ExecAt).HasColumnName("exec_at");

            builder.Property(e => e.ExecResult).HasColumnName("exec_result");

            builder.Property(e => e.JobClass)
                .HasColumnName("job_class")
                .HasColumnType("text(255)");

            builder.Property(e => e.JobGroup)
                .HasColumnName("job_group")
                .HasColumnType("text(50)");

            builder.Property(e => e.ModifyBy).HasColumnName("modify_by");

            builder.Property(e => e.ModifyTime).HasColumnName("modify_time");

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("text(50)");

            builder.Property(e => e.Note)
                .HasColumnName("note")
                .HasColumnType("text(255)");
        }
    }
}
