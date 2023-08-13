using RecyclingApp.Application.Exceptions;
using RecyclingApp.Application.Utilities;
using RecyclingApp.Domain.Model.Orders;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace RecyclingApp.Application.Orders.Utilities;

internal static class OrdersExtensions
{
    internal static IQueryable<Order> ApplyCreatedAtFilter(this IQueryable<Order> query, DateTime? minCreatedAt, DateTime? maxCreatedAt)
    {
        if (minCreatedAt.HasValue && maxCreatedAt.HasValue)
            query = query.Where(o => o.CreatedAt >= minCreatedAt && o.CreatedAt <= maxCreatedAt);

        return query;
    }

    internal static IOrderedQueryable<Order> ApplySorting(this IQueryable<Order> query, string[]? sortingParams)
    {
        if (!sortingParams.IsNullOrEmpty())
        {
            var orderingCount = 0;
            foreach (var param in sortingParams!)
            {
                var propertyName = param.Split('\u002C').Select(p => p.Trim().ToLower()).First();
                if (param.EndsWith("desc"))
                    query = orderingCount == 0
                        ? query.OrderByDescending(GetSortProperty(propertyName))
                        : query.ThenByDescending(GetSortProperty(propertyName));
                else
                    query = orderingCount == 0 
                        ? query.OrderBy(GetSortProperty(propertyName))
                        : query.ThenBy(GetSortProperty(propertyName));
                orderingCount++;
            }
            return query.ThenBy(o => o.Id);
        }
        else
            return query.OrderBy(o => o.Id);
    }

    private static Expression<Func<Order, object>> GetSortProperty(string property)
        => property switch
        {
            "status" => Order => Order.Status,
            "createdat" => Order => Order.CreatedAt,
            var unknownProperty => throw new SortingPropertyDoesNotExistException(unknownProperty)
        };
}