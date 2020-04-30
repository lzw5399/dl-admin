using Doublelives.Domain.Cms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doublelives.Persistence.TableBuilders
{
    public class CmsContactsBuilder : IEntityTypeConfiguration<CmsContacts>
    {
        public void Configure(EntityTypeBuilder<CmsContacts> builder)
        {
            builder
                .HasComment("邀约信息")
                .ToTable("cms_contacts");

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

            builder.Property(e => e.Email)
                .HasMaxLength(32)
                .HasComment("邮箱")
                .HasColumnName("email");

            builder.Property(e => e.Mobile)
                .HasMaxLength(64)
                .HasComment("联系电话")
                .HasColumnName("mobile");

            builder.Property(e => e.ModifyBy)
                .HasComment("最后修改者")
                .HasColumnName("modify_by");

            builder.Property(e => e.ModifyTime)
                .HasComment("最后修改时间")
                .HasColumnName("modify_time");

            builder.Property(e => e.Remark)
                .HasMaxLength(128)
                .HasComment("备注")
                .HasColumnName("remark");

            builder.Property(e => e.UserName)
                .HasMaxLength(64)
                .HasComment("邀约人名称")
                .HasColumnName("user_name");
        }
    }
}