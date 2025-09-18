using GenericRepositoryAndService.ApplicationCore.Abstractions.Repositories;
using GenericRepositoryAndService.ApplicationCore.Data;
using GenericRepositoryAndService.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace GenericRepositoryAndService.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(BloggingContext context)
        {
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity?> GetAsync(PrimaryKey key, CancellationToken ct = default)
        {
            return await _dbSet.FindAsync([key.Get()], ct);
        }

        public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            Guard.AgainstNull(entity, nameof(entity));

            await _dbSet.AddAsync(entity, cancellationToken);

            return entity;
        }

        public async Task<TEntity?> UpdateAsync(PrimaryKey key, TEntity entity, CancellationToken cancellationToken = default)
        {
            Guard.AgainstNull(entity, nameof(entity));

            _dbSet.Update(entity);

            return await Task.FromResult(entity);
        }

        public async Task<TEntity?> DeleteAsync(PrimaryKey key, CancellationToken cancellationToken = default)
        {
            var entity = await GetAsync(key, cancellationToken);

            Guard.AgainstNull(entity, nameof(entity));

            _dbSet.Remove(entity);

            return entity;
        }

        public async Task<IReadOnlyList<TEntity>> ListAsync(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool asNoTracking = true,
            CancellationToken ct = default)
        {
            var query = _dbSet.AsQueryable();

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            if(include != null)
            {
                query = include(query);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.ToListAsync(ct);
        }

        public async Task<(IReadOnlyList<TEntity> Items, int Total)> PageAsync(
            int page, int pageSize,
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool asNoTracking = true,
            CancellationToken ct = default)
        {
            if (page < 1)
            {
                page = 1;
            }

            if (pageSize < 1)
            {
                pageSize = 10;
            }

            var query = _dbSet.AsQueryable();

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            var total = await query.CountAsync(ct);

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(ct);

            return (items, total);
        }
    }
}

