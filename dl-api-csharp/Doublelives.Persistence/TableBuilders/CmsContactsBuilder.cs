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

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(e => e.CreateBy).HasColumnName("create_by");

            builder.Property(e => e.CreateTime).HasColumnName("create_time");

            builder.Property(e => e.Email)
                .HasColumnName("email")
                .HasColumnType("text(32)");

            builder.Property(e => e.Mobile)
                .HasColumnName("mobile")
                .HasColumnType("text(64)");

            builder.Property(e => e.ModifyBy).HasColumnName("modify_by");

            builder.Property(e => e.ModifyTime).HasColumnName("modify_time");

            builder.Property(e => e.Remark)
                .HasColumnName("remark")
                .HasColumnType("text(128)");

            builder.Property(e => e.UserName)
                .HasColumnName("user_name")
                .HasColumnType("text(64)");
        }
    }
}
