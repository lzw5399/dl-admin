using Doublelives.Domain.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doublelives.Persistence.TableBuilders
{
    public class MessageSenderBuilder : IEntityTypeConfiguration<MessageSender>
    {
        public void Configure(EntityTypeBuilder<MessageSender> builder)
        {
            builder
                .HasComment("消息发送者")
                .ToTable("message_sender");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasComment("主键")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.ClassName)
                .HasMaxLength(64)
                .HasComment("发送类")
                .HasColumnName("class_name");

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

            builder.Property(e => e.Name)
                .HasMaxLength(64)
                .HasComment("名称")
                .HasColumnName("name");

            builder.Property(e => e.TplCode)
                .HasMaxLength(64)
                .HasComment("运营商模板编号")
                .HasColumnName("tpl_code");
        }
    }
}
