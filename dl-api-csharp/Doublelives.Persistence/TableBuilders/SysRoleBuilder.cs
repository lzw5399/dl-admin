using Doublelives.Domain.Sys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doublelives.Persistence.TableBuilders
{
    public class SysRoleBuilder : IEntityTypeConfiguration<SysRole>
    {
        public void Configure(EntityTypeBuilder<SysRole> builder)
        {
            builder.ToTable("sys_role");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(e => e.CreateBy).HasColumnName("create_by");

            builder.Property(e => e.CreateTime).HasColumnName("create_time");

            builder.Property(e => e.Deptid).HasColumnName("deptid");

            builder.Property(e => e.ModifyBy).HasColumnName("modify_by");

            builder.Property(e => e.ModifyTime).HasColumnName("modify_time");

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("text(255)");

            builder.Property(e => e.Num).HasColumnName("num");

            builder.Property(e => e.Pid).HasColumnName("pid");

            builder.Property(e => e.Tips)
                .HasColumnName("tips")
                .HasColumnType("text(255)");

            builder.Property(e => e.Version).HasColumnName("version");
        }
    }
}
