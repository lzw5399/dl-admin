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

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(e => e.CreateTime).HasColumnName("create_time");

            builder.Property(e => e.Ip)
                .HasColumnName("ip")
                .HasColumnType("text(255)");

            builder.Property(e => e.Logname)
                .HasColumnName("logname")
                .HasColumnType("text(255)");

            builder.Property(e => e.Message)
                .HasColumnName("message")
                .HasColumnType("text(255)");

            builder.Property(e => e.Succeed)
                .HasColumnName("succeed")
                .HasColumnType("text(255)");

            builder.Property(e => e.Userid).HasColumnName("userid");
        }
    }
}
