using RecyclingApp.Domain.Primitives;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace RecyclingApp.Application.Utilities;

internal static class IQueryableExtensions
{
    internal static IOrderedQueryable<T> Sort<T>(
        this IQueryable<T> query,
        Func<string, Expression<Func<T, object>>> propertyProvider,
        string[]? sortingParams) where T : BaseEntity
    {
        if (!sortingParams.IsNullOrEmpty())
        {
            var orderingCount = 0;
            foreach (var param in sortingParams!)
            {
                var propertyName = param.Split('\u002C').Select(p => p.Trim().ToLower()).First();
                if (param.EndsWith("desc"))
                    query = orderingCount == 0
                        ? query.OrderByDescending(propertyProvider(propertyName))
                        : query.ThenByDescending(propertyProvider(propertyName));
                else
                    query = orderingCount == 0
                        ? query.OrderBy(propertyProvider(propertyName))
                        : query.ThenBy(propertyProvider(propertyName));
                orderingCount++;
            }
            return query.ThenBy(x => x.Id);
        }
        else
            return query.OrderBy(x => x.Id);
    }

    internal static IOrderedQueryable<T> ThenBy<T>(this IQueryable<T> query,
        Expression<Func<T, object>> key)
    {
        IOrderedQueryable<T> orderedQuery = (IOrderedQueryable<T>)query;
        return orderedQuery.ThenBy(keySelector: key);
    }

    internal static IOrderedQueryable<T> ThenByDescending<T>(this IQueryable<T> query,
        Expression<Func<T, object>> key)
    {
        IOrderedQueryable<T> orderedQuery = (IOrderedQueryable<T>)query;
        return orderedQuery.ThenByDescending(keySelector: key);
    }
}
