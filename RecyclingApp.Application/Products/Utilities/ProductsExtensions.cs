using RecyclingApp.Application.Exceptions;
using RecyclingApp.Application.Utilities;
using RecyclingApp.Domain.Model.Products;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace RecyclingApp.Application.Products.Utilities;

internal static class ProductsExtensions
{
    internal static IQueryable<Product> ApplyPriceFilter(this IQueryable<Product> query, decimal? minPrice, decimal? maxPrice)
        => query = minPrice.HasValue && maxPrice.HasValue
            ? query.Where(p => p.Price >= minPrice && p.Price <= maxPrice) 
            : minPrice.HasValue ? query.Where(p => p.Price >= minPrice) 
            : maxPrice.HasValue ? query.Where(p => p.Price <= maxPrice)
            : query;

    internal static IOrderedQueryable<Product> ApplySorting(this IQueryable<Product> query, string[]? sortingParams)
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

    private static Expression<Func<Product, object>> GetSortProperty(string property)
        => property switch
        {
            "name" => Product => Product.Name,
            "price" => Product => Product.Price,
            "type" => Product => Product.Type,
            var unknownProperty => throw new SortingPropertyDoesNotExistException(unknownProperty)
        };
}
