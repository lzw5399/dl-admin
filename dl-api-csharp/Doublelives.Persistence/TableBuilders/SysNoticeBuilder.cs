using Doublelives.Domain.Sys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doublelives.Persistence.TableBuilders
{
    public class SysNoticeBuilder : IEntityTypeConfiguration<SysNotice>
    {
        public void Configure(EntityTypeBuilder<SysNotice> builder)
        {
            builder.ToTable("sys_notice");

            builder.HasComment("通知");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("bigint(20)");

            builder.Property(e => e.Content)
                .HasColumnName("content")
                .HasColumnType("varchar(255)")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.CreateBy)
                .HasColumnName("create_by")
                .HasColumnType("bigint(20)")
                .HasComment("创建人");

            builder.Property(e => e.CreateTime)
                .HasColumnName("create_time")
                .HasColumnType("datetime")
                .HasComment("创建时间/注册时间");

            builder.Property(e => e.ModifyBy)
                .HasColumnName("modify_by")
                .HasColumnType("bigint(20)")
                .HasComment("最后更新人");

            builder.Property(e => e.ModifyTime)
                .HasColumnName("modify_time")
                .HasColumnType("datetime")
                .HasComment("最后更新时间");

            builder.Property(e => e.Title)
                .HasColumnName("title")
                .HasColumnType("varchar(255)")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.Type)
                .HasColumnName("type")
                .HasColumnType("int(11)");
        }
    }
}
