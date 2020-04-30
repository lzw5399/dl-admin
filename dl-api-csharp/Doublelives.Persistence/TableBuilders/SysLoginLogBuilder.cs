using Doublelives.Domain.Sys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doublelives.Persistence.TableBuilders
{
    public class SysLoginLogBuilder : IEntityTypeConfiguration<SysLoginLog>
    {
        public void Configure(EntityTypeBuilder<SysLoginLog> builder)
        {
            builder
                .HasComment("登录日志")
                .ToTable("sys_login_log");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasComment("主键")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.CreateTime)
                .HasComment("创建时间")
                .HasColumnName("create_time");

            builder.Property(e => e.Ip)
                .HasMaxLength(255)
                .HasComment("登录ip")
                .HasColumnName("ip");

            builder.Property(e => e.Logname)
                .HasMaxLength(255)
                .HasComment("登陆者姓名")
                .HasColumnName("logname");

            builder.Property(e => e.Message)
                .HasMaxLength(255)
                .HasComment("消息")
                .HasColumnName("message");

            builder.Property(e => e.Succeed)
                .HasComment("是否成功")
                .HasColumnName("succeed");

            builder.Property(e => e.Userid)
                .HasComment("用户id")
                .HasColumnName("userid");
        }
    }
}