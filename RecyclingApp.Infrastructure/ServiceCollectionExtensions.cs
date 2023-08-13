using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecyclingApp.Application.Abstractions;
using RecyclingApp.Domain.Interfaces;
using RecyclingApp.Infrastructure.Data;
using RecyclingApp.Infrastructure.Repositories;

namespace RecyclingApp.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DatabaseConnection")));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationContext>());
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
