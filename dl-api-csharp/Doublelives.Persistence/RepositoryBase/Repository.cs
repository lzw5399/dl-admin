using Doublelives.Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Doublelives.Persistence
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        private DbSet<TEntity> Entities { get; set; }

        public Repository(IAlbumDbContext context)
        {
            Entities = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAsQueryable()
        {
            return Entities.AsQueryable();
        }

        public virtual TEntity GetById(object id)
        {
            return Entities.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            Entities.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            Entities.Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            Entities.Remove(entity);
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await Entities.FindAsync(id);
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            await Entities.AddAsync(entity);
        }
    }
}
