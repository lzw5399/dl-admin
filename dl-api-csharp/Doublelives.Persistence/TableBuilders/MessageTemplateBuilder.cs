using Doublelives.Domain.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doublelives.Persistence.TableBuilders
{
    public class MessageTemplateBuilder : IEntityTypeConfiguration<MessageTemplate>
    {
        public void Configure(EntityTypeBuilder<MessageTemplate> builder)
        {
            builder.ToTable("message_template");

            builder.HasIndex(e => e.IdMessageSender)
                .HasName("FK942sadqk5x9kbrwil0psyek3n");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(e => e.Code)
                .HasColumnName("code")
                .HasColumnType("text(32)");

            builder.Property(e => e.Cond)
                .HasColumnName("cond")
                .HasColumnType("text(32)");

            builder.Property(e => e.Content).HasColumnName("content");

            builder.Property(e => e.CreateBy).HasColumnName("create_by");

            builder.Property(e => e.CreateTime).HasColumnName("create_time");

            builder.Property(e => e.IdMessageSender).HasColumnName("id_message_sender");

            builder.Property(e => e.ModifyBy).HasColumnName("modify_by");

            builder.Property(e => e.ModifyTime).HasColumnName("modify_time");

            builder.Property(e => e.Title)
                .HasColumnName("title")
                .HasColumnType("text(64)");

            builder.Property(e => e.Type)
                .HasColumnName("type")
                .HasColumnType("text(32)");

            builder.HasOne(d => d.IdMessageSenderNavigation)
                .WithMany(p => p.MessageTemplate)
                .HasForeignKey(d => d.IdMessageSender)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
