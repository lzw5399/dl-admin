using Doublelives.Domain.Sys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doublelives.Persistence.TableBuilders
{

    public class SysDictBuilder : IEntityTypeConfiguration<SysDict>
    {
        public void Configure(EntityTypeBuilder<SysDict> builder)
        {
            builder
                .HasComment("字典")
                .ToTable("sys_dict");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasComment("主键")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");

            builder.Property(e => e.Num)
                .HasMaxLength(255)
                .HasColumnName("num");

            builder.Property(e => e.Pid)
                .HasColumnName("pid");

            builder.Property(e => e.Tips)
                .HasMaxLength(255)
                .HasColumnName("tips");

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
