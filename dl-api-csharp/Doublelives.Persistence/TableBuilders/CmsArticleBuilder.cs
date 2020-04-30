using Doublelives.Domain.Cms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doublelives.Persistence.TableBuilders
{
    public class CmsArticleBuilder : IEntityTypeConfiguration<CmsArticle>
    {
        public void Configure(EntityTypeBuilder<CmsArticle> builder)
        {
            builder
                .HasComment("文章")
                .ToTable("cms_article");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasComment("主键")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Author)
                .HasColumnName("author")
                .HasComment("作者")
                .HasMaxLength(64);

            builder.Property(e => e.Content)
                .HasColumnName("content")
                .HasComment("内容")
                .HasMaxLength(65535);

            builder.Property(e => e.CreateBy)
                .HasComment("创建者")
                .HasColumnName("create_by");

            builder.Property(e => e.CreateTime)
                .HasComment("创建时间")
                .HasColumnName("create_time");

            builder.Property(e => e.IdChannel)
                .HasComment("栏目id")
                .HasColumnName("id_channel");

            builder.Property(e => e.Img)
                .HasComment("文章题图id")
                .HasMaxLength(64)
                .HasColumnName("img");

            builder.Property(e => e.ModifyBy)
                .HasComment("最后修改者")
                .HasColumnName("modify_by");

            builder.Property(e => e.ModifyTime)
                .HasComment("最后修改时间")
                .HasColumnName("modify_time");

            builder.Property(e => e.Title)
                .HasMaxLength(128)
                .HasComment("文章标题")
                .HasColumnName("title");
        }
    }
}