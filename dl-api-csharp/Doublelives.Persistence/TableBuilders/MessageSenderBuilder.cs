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

            builder.HasComment("消息发送者");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("INTEGER");

            builder.Property(e => e.ClassName)
                .HasColumnName("class_name")
                .HasColumnType("varchar(64)")
                .HasComment("发送类")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.CreateBy)
                .HasColumnName("create_by")
                .HasColumnType("INTEGER")
                .HasComment("创建人");

            builder.Property(e => e.CreateTime)
                .HasColumnName("create_time")
                .HasColumnType("datetime")
                .HasComment("创建时间/注册时间");

            builder.Property(e => e.ModifyBy)
                .HasColumnName("modify_by")
                .HasColumnType("INTEGER")
                .HasComment("最后更新人");

            builder.Property(e => e.ModifyTime)
                .HasColumnName("modify_time")
                .HasColumnType("datetime")
                .HasComment("最后更新时间");

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(64)")
                .HasComment("名称")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            builder.Property(e => e.TplCode)
                .HasColumnName("tpl_code")
                .HasColumnType("varchar(64)")
                .HasComment("短信运营商模板编号")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");
        }
    }
}
