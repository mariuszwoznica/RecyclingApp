using System;
using System.Linq;
using System.Linq.Expressions;

namespace RecyclingApp.Application.Utilities;

internal static class IQueryableExtensions
{
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
