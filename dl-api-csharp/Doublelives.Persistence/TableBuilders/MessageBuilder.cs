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

            builder.HasComment("历史消息");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("bigint(20)");

            builder.Property(e => e.Content)
                .HasColumnName("content")
                .HasColumnType("text")
                .HasComment("消息内容")
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

            builder.Property(e => e.ModifyBy)
                .HasColumnName("modify_by")
                .HasColumnType("bigint(20)")
                .HasComment("最后更新人");

            builder.Property(e => e.ModifyTime)
                .HasColumnName("modify_time")
                .HasColumnType("datetime")
                .HasComment("最后更新时间");

            builder.Property(e => e.Receiver)
                .HasColumnName("receiver")
                .HasColumnType("varchar(64)")
                .HasComment("接收者")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.State)
                .HasColumnName("state")
                .HasColumnType("varchar(32)")
                .HasComment("消息类型,0:初始,1:成功,2:失败")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.TplCode)
                .HasColumnName("tpl_code")
                .HasColumnType("varchar(32)")
                .HasComment("模板编码")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.Type)
                .HasColumnName("type")
                .HasColumnType("varchar(32)")
                .HasComment("消息类型,0:短信,1:邮件")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");
        }
    }
}
