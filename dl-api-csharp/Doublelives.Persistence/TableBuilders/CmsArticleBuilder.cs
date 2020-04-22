using Doublelives.Domain.Cms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doublelives.Persistence.TableBuilders
{
    public class CmsArticleBuilder : IEntityTypeConfiguration<CmsArticle>
    {
        public void Configure(EntityTypeBuilder<CmsArticle> builder)
        {
            builder.ToTable("cms_article");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(e => e.Author)
                .HasColumnName("author")
                .HasColumnType("text(64)");

            builder.Property(e => e.Content).HasColumnName("content");

            builder.Property(e => e.CreateBy).HasColumnName("create_by");

            builder.Property(e => e.CreateTime).HasColumnName("create_time");

            builder.Property(e => e.IdChannel).HasColumnName("id_channel");

            builder.Property(e => e.Img)
                .HasColumnName("img")
                .HasColumnType("text(64)");

            builder.Property(e => e.ModifyBy).HasColumnName("modify_by");

            builder.Property(e => e.ModifyTime).HasColumnName("modify_time");

            builder.Property(e => e.Title)
                .HasColumnName("title")
                .HasColumnType("text(128)");
        }
    }
}
