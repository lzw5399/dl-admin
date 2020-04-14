using System.Linq;

namespace Doublelives.Persistence
{
    public partial interface IRepository<TEntity>
    {
        IQueryable<TEntity> GetAsQueryable();

        TEntity GetById(object id);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
