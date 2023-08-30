using RecyclingApp.Application.Exceptions;
using RecyclingApp.Application.Utilities;
using RecyclingApp.Domain.Entities.Orders;
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
        => query.Sort(propertyProvider: GetProperty, sortingParams: sortingParams);

    private static Expression<Func<Order, object>> GetProperty(string propertyName)
        => propertyName switch
        {
            "status" => Order => Order.Status,
            "createdat" => Order => Order.CreatedAt,
            var unknownProperty => throw new SortingPropertyDoesNotExistException(unknownProperty)
        };
}