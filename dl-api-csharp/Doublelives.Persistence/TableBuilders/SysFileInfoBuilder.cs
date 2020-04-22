using Doublelives.Domain.Sys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doublelives.Persistence.TableBuilders
{
    public class SysFileInfoBuilder : IEntityTypeConfiguration<SysFileInfo>
    {
        public void Configure(EntityTypeBuilder<SysFileInfo> builder)
        {
            builder.ToTable("sys_file_info");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(e => e.CreateBy).HasColumnName("create_by");

            builder.Property(e => e.CreateTime).HasColumnName("create_time");

            builder.Property(e => e.ModifyBy).HasColumnName("modify_by");

            builder.Property(e => e.ModifyTime).HasColumnName("modify_time");

            builder.Property(e => e.OriginalFileName)
                .HasColumnName("original_file_name")
                .HasColumnType("text(255)");

            builder.Property(e => e.RealFileName)
                .HasColumnName("real_file_name")
                .HasColumnType("text(255)");
        }
    }
}
