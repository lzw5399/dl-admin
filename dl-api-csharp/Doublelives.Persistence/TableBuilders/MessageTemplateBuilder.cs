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

            builder.HasComment("消息模板");

            builder.HasIndex(e => e.IdMessageSender)
                .HasName("FK942sadqk5x9kbrwil0psyek3n");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("bigint(20)");

            builder.Property(e => e.Code)
                .HasColumnName("code")
                .HasColumnType("varchar(32)")
                .HasComment("编号")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.Cond)
                .HasColumnName("cond")
                .HasColumnType("varchar(32)")
                .HasComment("发送条件")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.Content)
                .HasColumnName("content")
                .HasColumnType("text")
                .HasComment("内容")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.CreateBy)
                .HasColumnName("create_by")
                .HasColumnType("bigint(20)")
                .HasComment("创建人");

            builder.Property(e => e.CreateTime)
                .HasColumnName("create_time")
                .HasColumnType("datetime")
                .HasComment("创建时间/注册时间");

            builder.Property(e => e.IdMessageSender)
                .HasColumnName("id_message_sender")
                .HasColumnType("bigint(20)")
                .HasComment("发送者id");

            builder.Property(e => e.ModifyBy)
                .HasColumnName("modify_by")
                .HasColumnType("bigint(20)")
                .HasComment("最后更新人");

            builder.Property(e => e.ModifyTime)
                .HasColumnName("modify_time")
                .HasColumnType("datetime")
                .HasComment("最后更新时间");

            builder.Property(e => e.Title)
                .HasColumnName("title")
                .HasColumnType("varchar(64)")
                .HasComment("标题")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.Type)
                .HasColumnName("type")
                .HasColumnType("varchar(32)")
                .HasComment("消息类型,0:短信,1:邮件")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.HasOne(d => d.IdMessageSenderNavigation)
                .WithMany(p => p.MessageTemplate)
                .HasForeignKey(d => d.IdMessageSender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK942sadqk5x9kbrwil0psyek3n");
        }
    }
}
