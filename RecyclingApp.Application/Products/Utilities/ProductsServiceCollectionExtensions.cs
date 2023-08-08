using Microsoft.Extensions.DependencyInjection;
using RecyclingApp.Application.Products.Searchers;

namespace RecyclingApp.Application.Products.Utilities;

internal static class ProductsServiceCollectionExtensions
{
    internal static IServiceCollection AddProducts(this IServiceCollection services)
        => services
            .AddScoped<IProductSearcher, ProductSearcher>();
}
