using Doublelives.Domain.Sys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doublelives.Persistence.TableBuilders
{
    public class SysNoticeBuilder : IEntityTypeConfiguration<SysNotice>
    {
        public void Configure(EntityTypeBuilder<SysNotice> builder)
        {
            builder
                .HasComment("欢迎弹窗")
                .ToTable("sys_notice");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasComment("主键")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Content)
                .HasMaxLength(255)
                .HasComment("内容")
                .HasColumnName("content");

            builder.Property(e => e.CreateBy)
                .HasComment("创建者")
                .HasColumnName("create_by");

            builder.Property(e => e.CreateTime)
                .HasComment("创建时间")
                .HasColumnName("create_time");

            builder.Property(e => e.ModifyBy)
                .HasComment("最后修改者")
                .HasColumnName("modify_by");

            builder.Property(e => e.ModifyTime)
                .HasComment("最后修改时间")
                .HasColumnName("modify_time");

            builder.Property(e => e.Title)
                .HasMaxLength(255)
                .HasComment("标题")
                .HasColumnName("title");

            builder.Property(e => e.Type)
                .HasColumnName("type");
        }
    }
}