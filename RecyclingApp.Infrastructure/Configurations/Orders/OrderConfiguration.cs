using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecyclingApp.Domain.Entities.Orders;

namespace RecyclingApp.Infrastructure.Configurations.Orders;

internal class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id).ValueGeneratedNever().IsRequired();
        builder.Property(o => o.CustomerId).IsRequired();
        builder.Property(o => o.Status).IsRequired();
        builder.HasMany(o => o.OrderItems).WithOne().HasForeignKey(i => i.OrderId);

        builder.Property(o => o.CreatedAt).IsRequired();
        builder.Property(o => o.ModifiedAt);
    }
}
