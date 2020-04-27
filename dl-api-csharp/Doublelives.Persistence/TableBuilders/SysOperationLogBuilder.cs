using Doublelives.Domain.Sys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doublelives.Persistence.TableBuilders
{
    public class SysOperationLogBuilder : IEntityTypeConfiguration<SysOperationLog>
    {
        public void Configure(EntityTypeBuilder<SysOperationLog> builder)
        {
            builder
                .HasComment("操作日志")
                .ToTable("sys_operation_log");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasComment("主键")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Classname)
                .HasMaxLength(255)
                .HasComment("操作类名")
                .HasColumnName("classname");

            builder.Property(e => e.CreateTime)
                .HasComment("创建时间")
                .HasColumnName("create_time");

            builder.Property(e => e.Logname)
                .HasMaxLength(255)
                .HasColumnName("logname");

            builder.Property(e => e.Logtype)
                .HasMaxLength(255)
                .HasColumnName("logtype");

            builder.Property(e => e.Message)
                .HasComment("详细信息")
                .HasColumnName("message");

            builder.Property(e => e.Method)
                .HasMaxLength(255)
                .HasComment("方法名")
                .HasColumnName("method");

            builder.Property(e => e.Succeed)
                .HasColumnName("succeed");

            builder.Property(e => e.Userid)
                .HasColumnName("userid");
        }
    }
}
