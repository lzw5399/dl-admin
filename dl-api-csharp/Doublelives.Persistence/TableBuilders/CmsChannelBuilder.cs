using Doublelives.Domain.Cms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doublelives.Persistence.TableBuilders
{
    public class CmsChannelBuilder : IEntityTypeConfiguration<CmsChannel>
    {
        public void Configure(EntityTypeBuilder<CmsChannel> builder)
        {
            builder
                .HasComment("文章栏目")
                .ToTable("cms_channel");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasComment("主键")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Code)
                .HasMaxLength(64)
                .HasComment("编码")
                .HasColumnName("code");

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

            builder.Property(e => e.Name)
                .HasMaxLength(64)
                .HasComment("名称")
                .HasColumnName("name");
        }
    }
}