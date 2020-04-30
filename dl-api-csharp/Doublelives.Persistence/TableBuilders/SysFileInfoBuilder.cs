using Doublelives.Domain.Sys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doublelives.Persistence.TableBuilders
{
    public class SysFileInfoBuilder : IEntityTypeConfiguration<SysFileInfo>
    {
        public void Configure(EntityTypeBuilder<SysFileInfo> builder)
        {
            builder
                .HasComment("文件信息")
                .ToTable("sys_file_info");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasComment("主键")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.OriginalFileName)
                .HasMaxLength(255)
                .HasComment("实际名称")
                .HasColumnName("original_file_name");

            builder.Property(e => e.RealFileName)
                .HasMaxLength(255)
                .HasComment("显示名称")
                .HasColumnName("real_file_name");

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
        }
    }
}