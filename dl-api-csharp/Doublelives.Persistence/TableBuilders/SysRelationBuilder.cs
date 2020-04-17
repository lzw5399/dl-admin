using Doublelives.Domain.Sys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doublelives.Persistence.TableBuilders
{
    public class SysRelationBuilder : IEntityTypeConfiguration<SysRelation>
    {
        public void Configure(EntityTypeBuilder<SysRelation> builder)
        {
            builder.ToTable("sys_relation");

            builder.HasComment("菜单角色关系");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("bigint(20)");

            builder.Property(e => e.Menuid)
                .HasColumnName("menuid")
                .HasColumnType("bigint(20)");

            builder.Property(e => e.Roleid)
                .HasColumnName("roleid")
                .HasColumnType("bigint(20)");
        }
    }
}
