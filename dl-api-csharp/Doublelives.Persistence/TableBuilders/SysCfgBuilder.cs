using Doublelives.Domain.Sys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doublelives.Persistence.TableBuilders
{
    public class SysCfgBuilder : IEntityTypeConfiguration<SysCfg>
    {
        public void Configure(EntityTypeBuilder<SysCfg> builder)
        {
            builder
                .HasComment("系统参数")
                .ToTable("sys_cfg");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasComment("主键")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.CfgDesc)
                .HasMaxLength(65535)
                .HasComment("备注")
                .HasColumnName("cfg_desc");

            builder.Property(e => e.CfgName)
                .HasMaxLength(256)
                .HasComment("参数名")
                .HasColumnName("cfg_name");

            builder.Property(e => e.CfgValue)
                .HasMaxLength(512)
                .HasComment("参数值")
                .HasColumnName("cfg_value");

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
