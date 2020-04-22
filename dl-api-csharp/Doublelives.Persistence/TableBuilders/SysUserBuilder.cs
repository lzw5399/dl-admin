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

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(e => e.Account)
                .HasColumnName("account")
                .HasColumnType("text(32)");

            builder.Property(e => e.Avatar)
                .HasColumnName("avatar")
                .HasColumnType("text(255)");

            builder.Property(e => e.Birthday).HasColumnName("birthday");

            builder.Property(e => e.CreateBy).HasColumnName("create_by");

            builder.Property(e => e.CreateTime).HasColumnName("create_time");

            builder.Property(e => e.Deptid).HasColumnName("deptid");

            builder.Property(e => e.Email)
                .HasColumnName("email")
                .HasColumnType("text(64)");

            builder.Property(e => e.ModifyBy).HasColumnName("modify_by");

            builder.Property(e => e.ModifyTime).HasColumnName("modify_time");

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("text(64)");

            builder.Property(e => e.Password)
                .HasColumnName("password")
                .HasColumnType("text(64)");

            builder.Property(e => e.Phone)
                .HasColumnName("phone")
                .HasColumnType("text(16)");

            builder.Property(e => e.Roleid)
                .HasColumnName("roleid")
                .HasColumnType("text(128)");

            builder.Property(e => e.Salt)
                .HasColumnName("salt")
                .HasColumnType("text(16)");

            builder.Property(e => e.Sex).HasColumnName("sex");

            builder.Property(e => e.Status).HasColumnName("status");

            builder.Property(e => e.Version).HasColumnName("version");
        }
    }
}
