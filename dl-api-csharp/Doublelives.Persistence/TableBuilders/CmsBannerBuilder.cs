using Doublelives.Domain.Cms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doublelives.Persistence.TableBuilders
{
    public class CmsBannerBuilder : IEntityTypeConfiguration<CmsBanner>
    {
        public void Configure(EntityTypeBuilder<CmsBanner> builder)
        {
            builder.ToTable("cms_banner");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasComment("主键")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.CreateBy)
                .HasComment("创建者")
                .HasColumnName("create_by");

            builder.Property(e => e.CreateTime)
                .HasComment("创建时间")
                .HasColumnName("create_time");

            builder.Property(e => e.IdFile)
                .HasComment("banner图id")
                .HasColumnName("id_file");

            builder.Property(e => e.ModifyBy)
                .HasComment("最后修改者")
                .HasColumnName("modify_by");

            builder.Property(e => e.ModifyTime)
                .HasComment("最后修改时间")
                .HasColumnName("modify_time");

            builder.Property(e => e.Title)
                .HasMaxLength(64)
                .HasComment("标题")
                .HasColumnName("title");

            builder.Property(e => e.Type)
                .HasColumnName("type")
                .HasComment("类型")
                .HasMaxLength(32);

            builder.Property(e => e.Url)
                .HasMaxLength(128)
                .HasComment("点击banner跳转到url")
                .HasColumnName("url");
        }
    }
}