using System.Linq.Expressions;

namespace BaseClassRepositoryAndExtension.Infrastructure.Repositories.Extensions
{
    public static class QueryExtension
    {
        public static IQueryable<T> WhereIf<T>(
            this IQueryable<T> source,
            bool condition,
            Expression<Func<T, bool>> predicate)
        {
            return condition ? source.Where(predicate) : source;
        }

        public static IQueryable<T> PageBy<T>(
            this IQueryable<T> source,
            int pageIndex,
            int pageSize)
        {
            return source.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public static IQueryable<T> OrderByIf<T, TKey>(
            this IQueryable<T> source,
            bool condition,
            Expression<Func<T, TKey>> keySelector,
            bool descending = false)
        {
            if (!condition) return source;

            return descending ? source.OrderByDescending(keySelector)
                              : source.OrderBy(keySelector);
        }
    }
}
