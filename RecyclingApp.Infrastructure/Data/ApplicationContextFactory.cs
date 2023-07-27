using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace RecyclingApp.Infrastructure.Data
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/../RecyclingApp.WebAPI/appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            var connectionStrings = configuration.GetConnectionString("DatabaseConnection");
            builder.UseNpgsql(connectionStrings);
            return new ApplicationContext(builder.Options);
        }
    }
}
