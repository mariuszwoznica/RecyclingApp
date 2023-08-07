using Microsoft.Extensions.DependencyInjection;
using RecyclingApp.Application.Orders.Searchers;

namespace RecyclingApp.Application.Orders;

internal static class OrdersServiceCollectionExtensions
{
    internal static IServiceCollection AddOrders(this IServiceCollection services)
        => services
            .AddScoped<IOrderSearcher, OrderSearcher>();
}
