using Doublelives.Domain.Sys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doublelives.Persistence.TableBuilders
{
    public class SysRelationBuilder : IEntityTypeConfiguration<SysRelation>
    {
        public void Configure(EntityTypeBuilder<SysRelation> builder)
        {
            builder
                .HasComment("角色和菜单的多对多中间表")
                .ToTable("sys_relation");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasComment("主键")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Menuid)
                .HasColumnName("menuid");

            builder.Property(e => e.Roleid)
                .HasColumnName("roleid");
        }
    }
}
