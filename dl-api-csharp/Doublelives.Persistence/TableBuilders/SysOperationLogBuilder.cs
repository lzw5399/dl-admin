using Doublelives.Domain.Sys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doublelives.Persistence.TableBuilders
{
    public class SysOperationLogBuilder : IEntityTypeConfiguration<SysOperationLog>
    {
        public void Configure(EntityTypeBuilder<SysOperationLog> builder)
        {
            builder.ToTable("sys_operation_log");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(e => e.Classname)
                .HasColumnName("classname")
                .HasColumnType("text(255)");

            builder.Property(e => e.CreateTime).HasColumnName("create_time");

            builder.Property(e => e.Logname)
                .HasColumnName("logname")
                .HasColumnType("text(255)");

            builder.Property(e => e.Logtype)
                .HasColumnName("logtype")
                .HasColumnType("text(255)");

            builder.Property(e => e.Message).HasColumnName("message");

            builder.Property(e => e.Method)
                .HasColumnName("method")
                .HasColumnType("text(255)");

            builder.Property(e => e.Succeed)
                .HasColumnName("succeed")
                .HasColumnType("text(255)");

            builder.Property(e => e.Userid).HasColumnName("userid");
        }
    }
}
