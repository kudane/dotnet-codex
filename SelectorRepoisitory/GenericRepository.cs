using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace SelectorRepoisitory;

public class GenericRepository<TEntity> where TEntity : class
{
    private BloggingContext _context { get; init; }

    public GenericRepository(BloggingContext context)
    {
        _context = context;
    }

    public IQueryable<TSelector> ListAsync<TSelector>(
        Expression<Func<TEntity, TSelector>> select,
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool asNoTracking = true,
        CancellationToken ct = default)
    {
        var query = _context.Set<TEntity>().AsQueryable();

        if (asNoTracking)
        {
            query = query.AsNoTracking();
        }

        if (include is not null)
        {
            query = include(query);
        }

        if (filter is not null)
        {
            query = query.Where(filter);
        }

        if (orderBy is not null)
        {
            query = orderBy(query);
        }

        return query.Select(select);
    }
}
