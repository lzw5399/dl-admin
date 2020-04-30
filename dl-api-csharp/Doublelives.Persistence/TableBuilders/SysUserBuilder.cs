using Doublelives.Domain.Sys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doublelives.Persistence.TableBuilders
{
    public class SysUserBuilder : IEntityTypeConfiguration<SysUser>
    {
        public void Configure(EntityTypeBuilder<SysUser> builder)
        {
            builder
                .HasComment("用户表")
                .ToTable("sys_user");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasComment("主键")
                .ValueGeneratedOnAdd();

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

            builder.Property(e => e.Account)
                .HasMaxLength(32)
                .HasComment("登录账户")
                .HasColumnName("account");

            builder.Property(e => e.Avatar)
                .HasMaxLength(255)
                .HasComment("头像")
                .HasColumnName("avatar");

            builder.Property(e => e.Birthday)
                .HasComment("生日")
                .HasColumnName("birthday");

            builder.Property(e => e.Deptid)
                .HasComment("部门id")
                .HasColumnName("deptid");

            builder.Property(e => e.Email)
                .HasMaxLength(64)
                .HasComment("电子邮箱")
                .HasColumnName("email");

            builder.Property(e => e.Name)
                .HasMaxLength(64)
                .HasComment("显示的姓名")
                .HasColumnName("name");

            builder.Property(e => e.Password)
                .HasMaxLength(64)
                .HasComment("加密后的密码")
                .HasColumnName("password");

            builder.Property(e => e.Phone)
                .HasMaxLength(16)
                .HasComment("联系电话")
                .HasColumnName("phone");

            builder.Property(e => e.Roleid)
                .HasMaxLength(128)
                .HasComment("角色id列表，以逗号分隔")
                .HasColumnName("roleid");

            builder.Property(e => e.Salt)
                .HasMaxLength(16)
                .HasComment("密码盐")
                .HasColumnName("salt");

            builder.Property(e => e.Sex)
                .HasComment("性别")
                .HasColumnName("sex");

            builder.Property(e => e.Status)
                .HasComment("账户状态")
                .HasColumnName("status");

            builder.Property(e => e.Version)
                .HasColumnName("version");
        }
    }
}