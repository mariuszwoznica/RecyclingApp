using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RecyclingApp.Application.Interfaces;
using RecyclingApp.Application.Orders;
using RecyclingApp.Application.Products;
using System.Reflection;

namespace RecyclingApp.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
        => services
            .AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()))
            .AddAutoMapper(Assembly.GetExecutingAssembly())
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
            .AddOrders()
            .AddProducts();

    internal static IServiceCollection RegisterResponseBuilder<TIn, TResponse, TBuilder>(this IServiceCollection serviceCollection)
        where TBuilder : class, IResponseBuilder<TIn, TResponse>
        => serviceCollection.AddScoped<IResponseBuilder<TIn, TResponse>, TBuilder>();
}