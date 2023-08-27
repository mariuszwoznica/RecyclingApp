using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecyclingApp.Domain.Entities.Products;

namespace RecyclingApp.Infrastructure.Configurations.Products;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(o => o.Id).ValueGeneratedNever().IsRequired();
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Type).IsRequired();
        builder.Property(p => p.Price).IsRequired();

        builder.Property(p => p.CreatedAt).IsRequired();
        builder.Property(p => p.ModifiedAt);
    }
}
