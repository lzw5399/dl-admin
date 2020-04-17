using Doublelives.Domain.Sys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doublelives.Persistence.TableBuilders
{
    public class SysLoginLogBuilder : IEntityTypeConfiguration<SysLoginLog>
    {
        public void Configure(EntityTypeBuilder<SysLoginLog> builder)
        {
            builder.ToTable("sys_login_log");

            builder.HasComment("登录日志");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int(11)");

            builder.Property(e => e.CreateTime)
                .HasColumnName("create_time")
                .HasColumnType("datetime")
                .HasComment("创建时间");

            builder.Property(e => e.Ip)
                .HasColumnName("ip")
                .HasColumnType("varchar(255)")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.Logname)
                .HasColumnName("logname")
                .HasColumnType("varchar(255)")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.Message)
                .HasColumnName("message")
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
                .HasColumnType("int(11)");
        }
    }
}
