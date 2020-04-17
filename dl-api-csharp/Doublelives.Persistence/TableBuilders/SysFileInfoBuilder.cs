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

            builder.HasComment("文件");

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

            builder.Property(e => e.ModifyBy)
                .HasColumnName("modify_by")
                .HasColumnType("bigint(20)")
                .HasComment("最后更新人");

            builder.Property(e => e.ModifyTime)
                .HasColumnName("modify_time")
                .HasColumnType("datetime")
                .HasComment("最后更新时间");

            builder.Property(e => e.OriginalFileName)
                .HasColumnName("original_file_name")
                .HasColumnType("varchar(255)")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.RealFileName)
                .HasColumnName("real_file_name")
                .HasColumnType("varchar(255)")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");
        }
    }
}
