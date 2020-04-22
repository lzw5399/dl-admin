using Doublelives.Domain.Sys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doublelives.Persistence.TableBuilders
{
    public class SysCfgBuilder : IEntityTypeConfiguration<SysCfg>
    {
        public void Configure(EntityTypeBuilder<SysCfg> builder)
        {
            builder.ToTable("sys_cfg");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(e => e.CfgDesc).HasColumnName("cfg_desc");

            builder.Property(e => e.CfgName)
                .HasColumnName("cfg_name")
                .HasColumnType("text(256)");

            builder.Property(e => e.CfgValue)
                .HasColumnName("cfg_value")
                .HasColumnType("text(512)");

            builder.Property(e => e.CreateBy).HasColumnName("create_by");

            builder.Property(e => e.CreateTime).HasColumnName("create_time");

            builder.Property(e => e.ModifyBy).HasColumnName("modify_by");

            builder.Property(e => e.ModifyTime).HasColumnName("modify_time");
        }
    }
}
