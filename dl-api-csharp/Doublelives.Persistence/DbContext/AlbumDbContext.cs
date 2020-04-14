using Doublelives.Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Doublelives.Persistence.Mapping;

namespace Doublelives.Persistence
{
    public class AlbumDbContext : DbContext, IAlbumDbContext
    {
        public AlbumDbContext(DbContextOptions opts)
        : base(opts)
        {
        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : EntityBase
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PictureEntityMapping());
            modelBuilder.ApplyConfiguration(new UserEntityMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
