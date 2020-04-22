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

            builder.HasComment("文章");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("INTEGER");

            builder.Property(e => e.Author)
                .HasColumnName("author")
                .HasColumnType("varchar(64)")
                .HasComment("作者")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.Content)
                .HasColumnName("content")
                .HasColumnType("text")
                .HasComment("内容")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.CreateBy)
                .HasColumnName("create_by")
                .HasColumnType("INTEGER")
                .HasComment("创建人");

            builder.Property(e => e.CreateTime)
                .HasColumnName("create_time")
                .HasColumnType("datetime")
                .HasComment("创建时间/注册时间");

            builder.Property(e => e.IdChannel)
                .HasColumnName("id_channel")
                .HasColumnType("INTEGER")
                .HasComment("栏目id");

            builder.Property(e => e.Img)
                .HasColumnName("img")
                .HasColumnType("varchar(64)")
                .HasComment("文章题图ID")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.ModifyBy)
                .HasColumnName("modify_by")
                .HasColumnType("INTEGER")
                .HasComment("最后更新人");

            builder.Property(e => e.ModifyTime)
                .HasColumnName("modify_time")
                .HasColumnType("datetime")
                .HasComment("最后更新时间");

            builder.Property(e => e.Title)
                .HasColumnName("title")
                .HasColumnType("varchar(128)")
                .HasComment("标题")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");
        }
    }
}
