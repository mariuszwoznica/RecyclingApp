using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecyclingApp.Application.Abstractions;
using RecyclingApp.Domain.Repositories;
using RecyclingApp.Infrastructure.Interceptors;
using RecyclingApp.Infrastructure.Repositories;

namespace RecyclingApp.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection serviceCollection, IConfiguration configuration)
            => serviceCollection
                .AddSingleton<AuditableEntitiesInterceptor>()
                .AddDbContext<ApplicationDbContext>((provider, options) =>
                {
                    options.UseNpgsql(configuration.GetConnectionString("DatabaseConnection"))
                        .AddInterceptors(provider.GetService<AuditableEntitiesInterceptor>()!);
                })                
                .AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>()!)
                .AddScoped(typeof(IRepository<>), typeof(Repository<>));
}
