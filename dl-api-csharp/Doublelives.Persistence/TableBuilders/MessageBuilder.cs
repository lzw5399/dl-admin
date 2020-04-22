using Doublelives.Domain.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doublelives.Persistence.TableBuilders
{
    public class MessageBuilder : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("message");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(e => e.Content).HasColumnName("content");

            builder.Property(e => e.CreateBy).HasColumnName("create_by");

            builder.Property(e => e.CreateTime).HasColumnName("create_time");

            builder.Property(e => e.ModifyBy).HasColumnName("modify_by");

            builder.Property(e => e.ModifyTime).HasColumnName("modify_time");

            builder.Property(e => e.Receiver)
                .HasColumnName("receiver")
                .HasColumnType("text(64)");

            builder.Property(e => e.State)
                .HasColumnName("state")
                .HasColumnType("text(32)");

            builder.Property(e => e.TplCode)
                .HasColumnName("tpl_code")
                .HasColumnType("text(32)");

            builder.Property(e => e.Type)
                .HasColumnName("type")
                .HasColumnType("text(32)");
        }
    }
}
