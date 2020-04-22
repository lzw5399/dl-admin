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

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(e => e.Menuid).HasColumnName("menuid");

            builder.Property(e => e.Roleid).HasColumnName("roleid");
        }
    }
}
