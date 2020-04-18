using System.Linq;
using System.Threading.Tasks;

namespace Doublelives.Persistence
{
    public partial interface IRepository<TEntity>
    {
        IQueryable<TEntity> GetAsQueryable();

        TEntity GetById(long id);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void DeleteById(long id);

        Task<TEntity> GetByIdAsync(long id);

        Task InsertAsync(TEntity entity);
    }
}
