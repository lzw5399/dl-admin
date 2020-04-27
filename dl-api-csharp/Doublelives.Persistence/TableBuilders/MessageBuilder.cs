using Doublelives.Domain.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doublelives.Persistence.TableBuilders
{
    public class MessageBuilder : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder
                .HasComment("历史消息")
                .ToTable("message");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasComment("主键")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Content)
                .HasMaxLength(65535)
                .HasComment("消息内容")
                .HasColumnName("content");

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

            builder.Property(e => e.Receiver)
                .HasMaxLength(64)
                .HasComment("接收者")
                .HasColumnName("receiver");

            builder.Property(e => e.State)
                .HasComment("消息类型,0:初始,1:成功,2:失败")
                .HasColumnName("state");

            builder.Property(e => e.TplCode)
                .HasMaxLength(32)
                .HasComment("模板编码")
                .HasColumnName("tpl_code");

            builder.Property(e => e.Type)
                .HasComment("消息类型,0:短信,1:邮件")
                .HasColumnName("type");
        }
    }
}
