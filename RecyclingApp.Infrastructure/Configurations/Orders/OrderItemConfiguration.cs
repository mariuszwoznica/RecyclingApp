using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecyclingApp.Domain.Entities.Orders;
using RecyclingApp.Domain.Entities.Products;

namespace RecyclingApp.Infrastructure.Configurations.Orders;

internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(i => new { i.OrderId, i.ProductId });
        builder.Property(i => i.Quantity).IsRequired();
        builder.HasOne<Order>().WithMany(o => o.OrderItems).HasForeignKey(i => i.OrderId);
        builder.HasOne<Product>().WithMany().HasForeignKey(i => i.ProductId);
    }
}
