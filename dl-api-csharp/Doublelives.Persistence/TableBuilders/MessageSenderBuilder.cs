using Doublelives.Domain.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doublelives.Persistence.TableBuilders
{
    public class MessageSenderBuilder : IEntityTypeConfiguration<MessageSender>
    {
        public void Configure(EntityTypeBuilder<MessageSender> builder)
        {
            builder.ToTable("message_sender");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(e => e.ClassName)
                .HasColumnName("class_name")
                .HasColumnType("text(64)");

            builder.Property(e => e.CreateBy).HasColumnName("create_by");

            builder.Property(e => e.CreateTime).HasColumnName("create_time");

            builder.Property(e => e.ModifyBy).HasColumnName("modify_by");

            builder.Property(e => e.ModifyTime).HasColumnName("modify_time");

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("text(64)");

            builder.Property(e => e.TplCode)
                .HasColumnName("tpl_code")
                .HasColumnType("text(64)");
        }
    }
}
