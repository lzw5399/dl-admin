using Doublelives.Domain.Sys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doublelives.Persistence.TableBuilders
{
    public class SysMenuBuilder : IEntityTypeConfiguration<SysMenu>
    {
        public void Configure(EntityTypeBuilder<SysMenu> builder)
        {
            builder
                .HasComment("菜单")
                .ToTable("sys_menu");

            builder.HasIndex(e => e.Code)
                .HasName("UK_s37unj3gh67ujhk83lqva8i1t")
                .IsUnique();

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasComment("主键")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(32)
                .HasComment("菜单编号")
                .HasColumnName("code");

            builder.Property(e => e.Component)
                .HasMaxLength(64)
                .HasComment("菜单对应的组件")
                .HasColumnName("component");

            builder.Property(e => e.Hidden)
                .HasComment("是否隐藏")
                .HasColumnName("hidden");

            builder.Property(e => e.Icon)
                .HasMaxLength(32)
                .HasComment("图标")
                .HasColumnName("icon");

            builder.Property(e => e.Ismenu)
                .HasComment("是否是菜单1:菜单,0:按钮")
                .HasColumnName("ismenu");

            builder.Property(e => e.Isopen)
                .HasComment("是否默认打开1:是,0:否")
                .HasColumnName("isopen");

            builder.Property(e => e.Levels)
                .HasComment("层级")
                .HasColumnName("levels");

            builder.Property(e => e.Name)
                .HasMaxLength(64)
                .IsRequired()
                .HasComment("名称")
                .HasColumnName("name");

            builder.Property(e => e.Num)
                .HasComment("顺序")
                .HasColumnName("num");

            builder.Property(e => e.Pcode)
                .HasMaxLength(64)
                .IsRequired()
                .HasComment("父菜单编号")
                .HasColumnName("pcode");

            builder.Property(e => e.Pcodes)
                .HasMaxLength(128)
                .HasComment("递归父级菜单编号")
                .HasColumnName("pcodes");

            builder.Property(e => e.Status)
                .HasComment("状态1:启用,0:禁用")
                .HasColumnName("status");

            builder.Property(e => e.Tips)
                .HasMaxLength(32)
                .HasComment("鼠标悬停提示信息")
                .HasColumnName("tips");

            builder.Property(e => e.Url)
                .HasMaxLength(32)
                .HasComment("链接")
                .HasColumnName("url");

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
