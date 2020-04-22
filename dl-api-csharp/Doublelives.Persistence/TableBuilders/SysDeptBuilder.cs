using Doublelives.Domain.Sys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doublelives.Persistence.TableBuilders
{
    public class SysDeptBuilder : IEntityTypeConfiguration<SysDept>
    {
        public void Configure(EntityTypeBuilder<SysDept> builder)
        {
            builder.ToTable("sys_dept");

            builder.HasComment("部门");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("INTEGER");

            builder.Property(e => e.CreateBy)
                .HasColumnName("create_by")
                .HasColumnType("INTEGER")
                .HasComment("创建人");

            builder.Property(e => e.CreateTime)
                .HasColumnName("create_time")
                .HasColumnType("datetime")
                .HasComment("创建时间/注册时间");

            builder.Property(e => e.Fullname)
                .HasColumnName("fullname")
                .HasColumnType("varchar(255)")
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

            builder.Property(e => e.Num)
                .HasColumnName("num")
                .HasColumnType("INTEGER");

            builder.Property(e => e.Pid)
                .HasColumnName("pid")
                .HasColumnType("INTEGER");

            builder.Property(e => e.Pids)
                .HasColumnName("pids")
                .HasColumnType("varchar(255)")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.Simplename)
                .HasColumnName("simplename")
                .HasColumnType("varchar(255)")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.Tips)
                .HasColumnName("tips")
                .HasColumnType("varchar(255)")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.Version)
                .HasColumnName("version")
                .HasColumnType("INTEGER");
        }
    }
}
