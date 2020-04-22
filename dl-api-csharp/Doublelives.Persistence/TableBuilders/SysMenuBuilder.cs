using Doublelives.Domain.Sys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doublelives.Persistence.TableBuilders
{
    public class SysMenuBuilder : IEntityTypeConfiguration<SysMenu>
    {
        public void Configure(EntityTypeBuilder<SysMenu> builder)
        {
            builder.ToTable("sys_menu");

            builder.HasComment("菜单");

            builder.HasIndex(e => e.Code)
                .HasName("UK_s37unj3gh67ujhk83lqva8i1t")
                .IsUnique();

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("INTEGER");

            builder.Property(e => e.Code)
                .IsRequired()
                .HasColumnName("code")
                .HasColumnType("varchar(32)")
                .HasComment("编号")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.Component)
                .HasColumnName("component")
                .HasColumnType("varchar(64)")
                .HasComment("页面组件")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.CreateBy)
                .HasColumnName("create_by")
                .HasColumnType("INTEGER")
                .HasComment("创建人");

            builder.Property(e => e.CreateTime)
                .HasColumnName("create_time")
                .HasColumnType("datetime")
                .HasComment("创建时间/注册时间");

            builder.Property(e => e.Hidden)
                .HasColumnName("hidden")
                .HasColumnType("tinyint(4)")
                .HasComment("是否隐藏");

            builder.Property(e => e.Icon)
                .HasColumnName("icon")
                .HasColumnType("varchar(32)")
                .HasComment("图标")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.Ismenu)
                .HasColumnName("ismenu")
                .HasColumnType("INTEGER")
                .HasComment("是否是菜单1:菜单,0:按钮");

            builder.Property(e => e.Isopen)
                .HasColumnName("isopen")
                .HasColumnType("INTEGER")
                .HasComment("是否默认打开1:是,0:否");

            builder.Property(e => e.Levels)
                .HasColumnName("levels")
                .HasColumnType("INTEGER")
                .HasComment("级别");

            builder.Property(e => e.ModifyBy)
                .HasColumnName("modify_by")
                .HasColumnType("INTEGER")
                .HasComment("最后更新人");

            builder.Property(e => e.ModifyTime)
                .HasColumnName("modify_time")
                .HasColumnType("datetime")
                .HasComment("最后更新时间");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("varchar(64)")
                .HasComment("名称")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.Num)
                .HasColumnName("num")
                .HasColumnType("INTEGER")
                .HasComment("顺序");

            builder.Property(e => e.Pcode)
                .IsRequired()
                .HasColumnName("pcode")
                .HasColumnType("varchar(64)")
                .HasComment("父菜单编号")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.Pcodes)
                .HasColumnName("pcodes")
                .HasColumnType("varchar(128)")
                .HasComment("递归父级菜单编号")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.Status)
                .HasColumnName("status")
                .HasColumnType("INTEGER")
                .HasComment("状态1:启用,0:禁用");

            builder.Property(e => e.Tips)
                .HasColumnName("tips")
                .HasColumnType("varchar(32)")
                .HasComment("鼠标悬停提示信息")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.Url)
                .HasColumnName("url")
                .HasColumnType("varchar(32)")
                .HasComment("链接标识")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");
        }
    }
}
