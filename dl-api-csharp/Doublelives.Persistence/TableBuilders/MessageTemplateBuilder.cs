using Doublelives.Domain.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doublelives.Persistence.TableBuilders
{
    public class MessageTemplateBuilder : IEntityTypeConfiguration<MessageTemplate>
    {
        public void Configure(EntityTypeBuilder<MessageTemplate> builder)
        {
            builder
                .HasComment("消息模板")
                .ToTable("message_template");

            builder.HasIndex(e => e.IdMessageSender)
                .HasName("FK942sadqk5x9kbrwil0psyek3n");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasComment("主键")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Code)
                .HasMaxLength(32)
                .HasComment("编号")
                .HasColumnName("code");

            builder.Property(e => e.Cond)
                .HasMaxLength(32)
                .HasComment("发送条件")
                .HasColumnName("cond");

            builder.Property(e => e.Content)
                .HasMaxLength(65535)
                .HasComment("内容")
                .HasColumnName("content");

            builder.Property(e => e.CreateBy)
                .HasComment("创建者")
                .HasColumnName("create_by");

            builder.Property(e => e.CreateTime)
                .HasComment("创建时间")
                .HasColumnName("create_time");

            builder.Property(e => e.IdMessageSender)
                .HasComment("发送者id")
                .HasColumnName("id_message_sender");

            builder.Property(e => e.ModifyBy)
                .HasComment("最后修改者")
                .HasColumnName("modify_by");

            builder.Property(e => e.ModifyTime)
                .HasComment("最后修改时间")
                .HasColumnName("modify_time");

            builder.Property(e => e.Title)
                .HasMaxLength(64)
                .HasComment("标题")
                .HasColumnName("title");

            builder.Property(e => e.Type)
                .HasComment("消息类型,0:短信,1:邮件")
                .HasColumnName("type");

            builder.HasOne(d => d.IdMessageSenderNavigation)
                .WithMany(p => p.MessageTemplate)
                .HasForeignKey(d => d.IdMessageSender)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
