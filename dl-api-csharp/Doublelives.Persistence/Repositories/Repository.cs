using Doublelives.Domain.Infrastructure;
using Doublelives.Infrastructure.Extensions;
using Doublelives.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public PagedModel<TEntity> Paged<TProperty>(
            int pageNumber,
            int pageSize,
            Expression<Func<TEntity, bool>> whereExpression,
            Expression<Func<TEntity, TProperty>> orderByExpression,
            bool ascending = false)
        {
            var query = Entities.Where(whereExpression);

            var total = query.Count();
            if (total == 0) return new PagedModel<TEntity>() {PageSize = pageSize};

            if (pageNumber <= 0) pageNumber = 1;
            if (pageSize <= 0) pageSize = 10;

            query = ascending ? query.OrderBy(orderByExpression) : query.OrderByDescending(orderByExpression);
            var data = query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToArray();

            return new PagedModel<TEntity>()
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = total,
                Data = data,
                Ascending = ascending,
                Sort = orderByExpression.GetMemberName()
            };
        }

        public async Task<PagedModel<TEntity>> PagedAsync<TProperty>(
            int pageNumber,
            int pageSize,
            Expression<Func<TEntity, bool>> whereExpression,
            Expression<Func<TEntity, TProperty>> orderByExpression,
            bool ascending = false)
        {
            var total = await Entities.CountAsync();
            if (total == 0) return new PagedModel<TEntity>() {PageSize = pageSize};

            if (pageNumber <= 0) pageNumber = 1;
            if (pageSize <= 0) pageSize = 10;

            var query = Entities.Where(whereExpression);
            query = ascending ? query.OrderBy(orderByExpression) : query.OrderByDescending(orderByExpression);
            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToArrayAsync();

            return new PagedModel<TEntity>()
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = total,
                Data = data,
                Ascending = ascending,
                Sort = orderByExpression.GetMemberName()
            };
        }

        public IEnumerable<TEntity> GetByIds(int[] ids)
        {
            return Entities.Where(it => ids.Contains(it.Id)).ToList();
        }

        public async Task<IEnumerable<TEntity>> GetByIdsAsync(int[] ids)
        {
            return await Entities.Where(it => ids.Contains(it.Id)).ToListAsync();
        }
    }
}