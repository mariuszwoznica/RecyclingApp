using Microsoft.EntityFrameworkCore;
using RecyclingApp.Application.Interfaces;
using RecyclingApp.Domain.Common;
using RecyclingApp.Domain.Model;
using RecyclingApp.Domain.Model.Orders;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Infrastructure.Data
{
    public class ApplicationContext : DbContext, IApplicationDbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>()
                .HasKey(i => new { i.OrderId, i.ProductId });

            foreach (var entityType in modelBuilder.Model.GetEntityTypes()
                .Where(entity => typeof(IAuditable).IsAssignableFrom(entity.ClrType)))
            {
                modelBuilder.Entity(entityType.ClrType)
                    .Property<DateTime>("CreatedAt");
            }

            foreach (var entityType in modelBuilder.Model.GetEntityTypes()
                .Where(entity => entity.ClrType.IsAssignableFrom(typeof(BaseEntity))))
            {
                modelBuilder.Entity(entityType.ClrType)
                    .Property<Guid>("Id").HasDefaultValueSql("uuid_generate_v4()");
            }
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasPostgresExtension("uuid-ossp");
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyAuditInformation();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void ApplyAuditInformation()
        {
            var entities = ChangeTracker.Entries<IAuditable>()
                .Where(entity => entity.State == EntityState.Added);
            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                    entity.Property("CreatedAt").CurrentValue = DateTime.UtcNow;
            }
        }

    }
}
