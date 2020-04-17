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

            builder.HasComment("Banner");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("bigint(20)");

            builder.Property(e => e.CreateBy)
                .HasColumnName("create_by")
                .HasColumnType("bigint(20)")
                .HasComment("创建人");

            builder.Property(e => e.CreateTime)
                .HasColumnName("create_time")
                .HasColumnType("datetime")
                .HasComment("创建时间/注册时间");

            builder.Property(e => e.IdFile)
                .HasColumnName("id_file")
                .HasColumnType("bigint(20)")
                .HasComment("banner图id");

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
                .HasColumnType("varchar(64)")
                .HasComment("标题")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.Type)
                .HasColumnName("type")
                .HasColumnType("varchar(32)")
                .HasComment("类型")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.Url)
                .HasColumnName("url")
                .HasColumnType("varchar(128)")
                .HasComment("点击banner跳转到url")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");
        }
    }
}
