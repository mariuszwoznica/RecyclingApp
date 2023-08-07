using System;
using System.Linq;
using System.Linq.Expressions;

namespace RecyclingApp.Application.Helpers;

internal static class FilteringExtensions
{
    public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, int page, int limit)
    {
        return query
            .Skip((page - 1) * limit)
            .Take(limit);
    }

    internal static IQueryable<T> ApplaySorting<T>(this IQueryable<T> query, string? sortingParams)
    {
        if (sortingParams != null)
        {
            string[] paramiters = sortingParams.Split('\u002C').Select(p => p.Trim()).ToArray();
            var orderingCount = 0;
            foreach (var param in paramiters)
            {
                if (sortingParams.EndsWith("desc"))
                {
                    var method = "ThenByDescending";
                    var parameter = param.Replace("desc", "").Trim();
                    query = query.OrderBy(parameter, method);
                }
                else
                {
                    var method = "ThenBy";
                    query = query.OrderBy(param, method);
                }
                orderingCount++;
            }
        }
        return query;
    }

    private static IQueryable<T> OrderBy<T>(this IQueryable<T> query, string sortField, string method)
    {
        var param = Expression.Parameter(typeof(T));
        var property = Expression.Property(param, sortField);
        var expresion = Expression.Lambda(property, param);
        Type[] types = new Type[] { query.ElementType, expresion.Body.Type };
        var result = Expression.Call(typeof(Queryable), method, types, query.Expression, expresion);
        return query.Provider.CreateQuery<T>(result);
    }
}
