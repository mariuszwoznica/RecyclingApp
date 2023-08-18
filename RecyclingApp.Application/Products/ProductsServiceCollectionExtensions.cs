using Microsoft.Extensions.DependencyInjection;
using RecyclingApp.Application.Products.Builders;
using RecyclingApp.Application.Products.Models;
using RecyclingApp.Application.Products.Searchers;
using RecyclingApp.Domain.Entities.Products;

namespace RecyclingApp.Application.Products;

internal static class ProductsServiceCollectionExtensions
{
    internal static IServiceCollection AddProducts(this IServiceCollection services)
        => services
            .AddScoped<IProductSearcher, ProductSearcher>()
            .RegisterResponseBuilder<Product, ProductResponse, ProductResponseBuilder>();
}