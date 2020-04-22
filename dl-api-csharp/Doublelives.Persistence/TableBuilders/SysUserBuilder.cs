using Doublelives.Domain.Sys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doublelives.Persistence.TableBuilders
{
    public class SysUserBuilder : IEntityTypeConfiguration<SysUser>
    {
        public void Configure(EntityTypeBuilder<SysUser> builder)
        {
            builder.ToTable("sys_user");

            builder.HasComment("账号");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("INTEGER");

            builder.Property(e => e.Account)
                .HasColumnName("account")
                .HasColumnType("varchar(32)")
                .HasComment("账户")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.Avatar)
                .HasColumnName("avatar")
                .HasColumnType("varchar(255)")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.Birthday)
                .HasColumnName("birthday")
                .HasColumnType("datetime");

            builder.Property(e => e.CreateBy)
                .HasColumnName("create_by")
                .HasColumnType("INTEGER")
                .HasComment("创建人");

            builder.Property(e => e.CreateTime)
                .HasColumnName("create_time")
                .HasColumnType("datetime")
                .HasComment("创建时间/注册时间");

            builder.Property(e => e.Deptid)
                .HasColumnName("deptid")
                .HasColumnType("INTEGER");

            builder.Property(e => e.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(64)")
                .HasComment("email")
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

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(64)")
                .HasComment("姓名")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.Password)
                .HasColumnName("password")
                .HasColumnType("varchar(64)")
                .HasComment("密码")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.Phone)
                .HasColumnName("phone")
                .HasColumnType("varchar(16)")
                .HasComment("手机号")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.Roleid)
                .HasColumnName("roleid")
                .HasColumnType("varchar(128)")
                .HasComment("角色id列表，以逗号分隔")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.Salt)
                .HasColumnName("salt")
                .HasColumnType("varchar(16)")
                .HasComment("密码盐")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.Sex)
                .HasColumnName("sex")
                .HasColumnType("INTEGER");

            builder.Property(e => e.Status)
                .HasColumnName("status")
                .HasColumnType("INTEGER");

            builder.Property(e => e.Version)
                .HasColumnName("version")
                .HasColumnType("INTEGER");
        }
    }
}
