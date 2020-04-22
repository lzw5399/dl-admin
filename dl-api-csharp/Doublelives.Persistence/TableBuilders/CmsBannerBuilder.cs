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
                .ValueGeneratedNever();

            builder.Property(e => e.CreateBy).HasColumnName("create_by");

            builder.Property(e => e.CreateTime).HasColumnName("create_time");

            builder.Property(e => e.IdFile).HasColumnName("id_file");

            builder.Property(e => e.ModifyBy).HasColumnName("modify_by");

            builder.Property(e => e.ModifyTime).HasColumnName("modify_time");

            builder.Property(e => e.Title)
                .HasColumnName("title")
                .HasColumnType("text(64)");

            builder.Property(e => e.Type)
                .HasColumnName("type")
                .HasColumnType("text(32)");

            builder.Property(e => e.Url)
                .HasColumnName("url")
                .HasColumnType("text(128)");
        }
    }
}
