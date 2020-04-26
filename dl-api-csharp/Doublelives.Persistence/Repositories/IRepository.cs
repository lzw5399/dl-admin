using Doublelives.Shared.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Doublelives.Persistence
{
    public partial interface IRepository<TEntity>
    {
        IQueryable<TEntity> GetAsQueryable();

        TEntity GetById(long id);

        IEnumerable<TEntity> GetByIds(int[] ids);

        Task<IEnumerable<TEntity>> GetByIdsAsync(int[] ids);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void DeleteById(long id);

        Task<TEntity> GetByIdAsync(long id);

        Task InsertAsync(TEntity entity);

        PagedModel<TEntity> Paged<TProperty>(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, TProperty>> orderByExpression, bool ascending = false);
        
        Task<PagedModel<TEntity>> PagedAsync<TProperty>(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, TProperty>> orderByExpression, bool ascending = false);
    }
}
