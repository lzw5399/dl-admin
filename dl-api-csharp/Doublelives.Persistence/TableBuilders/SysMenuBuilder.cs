using Doublelives.Domain.Sys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doublelives.Persistence.TableBuilders
{
    public class SysMenuBuilder : IEntityTypeConfiguration<SysMenu>
    {
        public void Configure(EntityTypeBuilder<SysMenu> builder)
        {
            builder.ToTable("sys_menu");

            builder.HasIndex(e => e.Code)
                .HasName("UK_s37unj3gh67ujhk83lqva8i1t")
                .IsUnique();

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(e => e.Code)
                .IsRequired()
                .HasColumnName("code")
                .HasColumnType("text(32)");

            builder.Property(e => e.Component)
                .HasColumnName("component")
                .HasColumnType("text(64)");

            builder.Property(e => e.CreateBy).HasColumnName("create_by");

            builder.Property(e => e.CreateTime).HasColumnName("create_time");

            builder.Property(e => e.Hidden).HasColumnName("hidden");

            builder.Property(e => e.Icon)
                .HasColumnName("icon")
                .HasColumnType("text(32)");

            builder.Property(e => e.Ismenu).HasColumnName("ismenu");

            builder.Property(e => e.Isopen).HasColumnName("isopen");

            builder.Property(e => e.Levels).HasColumnName("levels");

            builder.Property(e => e.ModifyBy).HasColumnName("modify_by");

            builder.Property(e => e.ModifyTime).HasColumnName("modify_time");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("text(64)");

            builder.Property(e => e.Num).HasColumnName("num");

            builder.Property(e => e.Pcode)
                .IsRequired()
                .HasColumnName("pcode")
                .HasColumnType("text(64)");

            builder.Property(e => e.Pcodes)
                .HasColumnName("pcodes")
                .HasColumnType("text(128)");

            builder.Property(e => e.Status).HasColumnName("status");

            builder.Property(e => e.Tips)
                .HasColumnName("tips")
                .HasColumnType("text(32)");

            builder.Property(e => e.Url)
                .HasColumnName("url")
                .HasColumnType("text(32)");
        }
    }
}
