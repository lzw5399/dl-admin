using Doublelives.Domain.Cms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doublelives.Persistence.TableBuilders
{
    public class CmsContactsBuilder : IEntityTypeConfiguration<CmsContacts>
    {
        public void Configure(EntityTypeBuilder<CmsContacts> builder)
        {
            builder.ToTable("cms_contacts");

            builder.HasComment("邀约信息");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("INTEGER");

            builder.Property(e => e.CreateBy)
                .HasColumnName("create_by")
                .HasColumnType("INTEGER")
                .HasComment("创建人");

            builder.Property(e => e.CreateTime)
                .HasColumnName("create_time")
                .HasColumnType("datetime")
                .HasComment("创建时间/注册时间");

            builder.Property(e => e.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(32)")
                .HasComment("电子邮箱")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.Mobile)
                .HasColumnName("mobile")
                .HasColumnType("varchar(64)")
                .HasComment("联系电话")
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

            builder.Property(e => e.Remark)
                .HasColumnName("remark")
                .HasColumnType("varchar(128)")
                .HasComment("备注")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.UserName)
                .HasColumnName("user_name")
                .HasColumnType("varchar(64)")
                .HasComment("邀约人名称")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");
        }
    }
}
