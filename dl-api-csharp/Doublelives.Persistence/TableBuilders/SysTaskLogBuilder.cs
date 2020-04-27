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

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(e => e.ExecAt).HasColumnName("exec_at");

            builder.Property(e => e.ExecSuccess).HasColumnName("exec_success");

            builder.Property(e => e.IdTask).HasColumnName("id_task");

            builder.Property(e => e.JobException)
                .HasColumnName("job_exception")
                .HasColumnType("text(500)");

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("text(50)");
        }
    }
}
