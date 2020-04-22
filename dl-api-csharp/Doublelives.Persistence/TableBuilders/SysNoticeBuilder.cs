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

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(e => e.Content)
                .HasColumnName("content")
                .HasColumnType("text(255)");

            builder.Property(e => e.CreateBy).HasColumnName("create_by");

            builder.Property(e => e.CreateTime).HasColumnName("create_time");

            builder.Property(e => e.ModifyBy).HasColumnName("modify_by");

            builder.Property(e => e.ModifyTime).HasColumnName("modify_time");

            builder.Property(e => e.Title)
                .HasColumnName("title")
                .HasColumnType("text(255)");

            builder.Property(e => e.Type).HasColumnName("type");
        }
    }
}
