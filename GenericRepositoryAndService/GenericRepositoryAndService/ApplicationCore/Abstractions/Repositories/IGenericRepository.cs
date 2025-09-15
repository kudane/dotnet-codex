using GenericRepositoryAndService.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace GenericRepositoryAndService.ApplicationCore.Abstractions.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetAsync(PrimaryKey key, CancellationToken ct = default);

        Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task<TEntity?> UpdateAsync(PrimaryKey key, TEntity entity, CancellationToken cancellationToken = default);

        Task<TEntity?> DeleteAsync(PrimaryKey key, CancellationToken cancellationToken = default);

        Task<IReadOnlyList<TEntity>> ListAsync(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool asNoTracking = false,
            CancellationToken ct = default);

        Task<(IReadOnlyList<TEntity> Items, int Total)> PageAsync(
            int page, int pageSize,
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool asNoTracking = true,
            CancellationToken ct = default);
    }
}
