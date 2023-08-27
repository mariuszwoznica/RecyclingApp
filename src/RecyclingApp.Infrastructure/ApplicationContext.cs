using Microsoft.EntityFrameworkCore;
using RecyclingApp.Application.Abstractions;
using RecyclingApp.Domain.Entities;
using RecyclingApp.Domain.Entities.Orders;
using RecyclingApp.Domain.Entities.Products;

namespace RecyclingApp.Infrastructure;

public class ApplicationContext : DbContext, IApplicationDbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}