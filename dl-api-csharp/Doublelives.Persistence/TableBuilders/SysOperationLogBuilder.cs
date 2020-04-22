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

            builder.HasComment("操作日志");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("INTEGER");

            builder.Property(e => e.Classname)
                .HasColumnName("classname")
                .HasColumnType("varchar(255)")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.CreateTime)
                .HasColumnName("create_time")
                .HasColumnType("datetime");

            builder.Property(e => e.Logname)
                .HasColumnName("logname")
                .HasColumnType("varchar(255)")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.Logtype)
                .HasColumnName("logtype")
                .HasColumnType("varchar(255)")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.Message)
                .HasColumnName("message")
                .HasColumnType("text")
                .HasComment("详细信息")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.Method)
                .HasColumnName("method")
                .HasColumnType("varchar(255)")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.Succeed)
                .HasColumnName("succeed")
                .HasColumnType("varchar(255)")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.Userid)
                .HasColumnName("userid")
                .HasColumnType("INTEGER");
        }
    }
}
