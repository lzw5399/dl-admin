using Doublelives.Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Doublelives.Persistence
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        private DbSet<TEntity> Entities { get; set; }

        public Repository(DlAdminDbContext context)
        {
            Entities = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAsQueryable()
        {
            return Entities.AsQueryable();
        }

        public virtual TEntity GetById(long id)
        {
            return Entities.FirstOrDefault(it => it.Id == id);
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

        public virtual void DeleteById(long id)
        {
            var obj = Entities.FirstOrDefault(it => it.Id == id);
            if (obj == null) return;

            Entities.Remove(obj);
        }

        public virtual async Task<TEntity> GetByIdAsync(long id)
        {
            return await Entities.FirstOrDefaultAsync(it => it.Id == id);
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            await Entities.AddAsync(entity);
        }
    }
}
