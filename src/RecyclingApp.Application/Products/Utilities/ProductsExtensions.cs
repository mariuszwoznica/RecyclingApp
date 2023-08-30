using RecyclingApp.Application.Exceptions;
using RecyclingApp.Application.Utilities;
using RecyclingApp.Domain.Entities.Products;
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
        => query.Sort(propertyProvider: GetProperty, sortingParams: sortingParams);

    private static Expression<Func<Product, object>> GetProperty(string propertyName)
        => propertyName switch
        {
            "name" => Product => Product.Name,
            "price" => Product => Product.Price,
            "type" => Product => Product.Type,
            var unknownProperty => throw new SortingPropertyDoesNotExistException(unknownProperty)
        };
}
