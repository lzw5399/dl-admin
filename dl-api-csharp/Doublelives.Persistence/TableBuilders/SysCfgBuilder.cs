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

            builder.HasComment("系统参数");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("bigint(20)");

            builder.Property(e => e.CfgDesc)
                .HasColumnName("cfg_desc")
                .HasColumnType("text")
                .HasComment("备注")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.CfgName)
                .HasColumnName("cfg_name")
                .HasColumnType("varchar(256)")
                .HasComment("参数名")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.CfgValue)
                .HasColumnName("cfg_value")
                .HasColumnType("varchar(512)")
                .HasComment("参数值")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

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
        }
    }
}
