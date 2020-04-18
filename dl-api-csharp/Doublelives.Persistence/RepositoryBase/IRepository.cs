using System.Linq;
using System.Threading.Tasks;

namespace Doublelives.Persistence
{
    public partial interface IRepository<TEntity>
    {
        IQueryable<TEntity> GetAsQueryable();

        TEntity GetById(object id);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void DeleteById(int id);

        Task<TEntity> GetByIdAsync(object id);

        Task InsertAsync(TEntity entity);
    }
}
