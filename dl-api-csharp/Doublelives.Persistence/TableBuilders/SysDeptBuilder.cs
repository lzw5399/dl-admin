using Doublelives.Domain.Sys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doublelives.Persistence.TableBuilders
{
    public class SysDeptBuilder : IEntityTypeConfiguration<SysDept>
    {
        public void Configure(EntityTypeBuilder<SysDept> builder)
        {
            builder
                .HasComment("部门")
                .ToTable("sys_dept");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasComment("主键")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Fullname)
                .HasMaxLength(255)
                .HasComment("全称")
                .HasColumnName("fullname");

            builder.Property(e => e.Num)
                .HasColumnName("num");

            builder.Property(e => e.Pid)
                .HasColumnName("pid");

            builder.Property(e => e.Pids)
                .HasMaxLength(255)
                .HasColumnName("pids");

            builder.Property(e => e.Simplename)
                .HasMaxLength(255)
                .HasComment("简称")
                .HasColumnName("simplename");

            builder.Property(e => e.Tips)
                .HasMaxLength(255)
                .HasColumnName("tips");

            builder.Property(e => e.Version)
                .HasColumnName("version");

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
