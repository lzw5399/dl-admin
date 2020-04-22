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

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(e => e.CreateBy).HasColumnName("create_by");

            builder.Property(e => e.CreateTime).HasColumnName("create_time");

            builder.Property(e => e.Fullname)
                .HasColumnName("fullname")
                .HasColumnType("text(255)");

            builder.Property(e => e.ModifyBy).HasColumnName("modify_by");

            builder.Property(e => e.ModifyTime).HasColumnName("modify_time");

            builder.Property(e => e.Num).HasColumnName("num");

            builder.Property(e => e.Pid).HasColumnName("pid");

            builder.Property(e => e.Pids)
                .HasColumnName("pids")
                .HasColumnType("text(255)");

            builder.Property(e => e.Simplename)
                .HasColumnName("simplename")
                .HasColumnType("text(255)");

            builder.Property(e => e.Tips)
                .HasColumnName("tips")
                .HasColumnType("text(255)");

            builder.Property(e => e.Version).HasColumnName("version");
        }
    }
}
