using RecyclingApp.Domain.Primitives;
using System;

namespace RecyclingApp.Domain.Entities.Products;

public class Product : BaseEntity, IAuditableEntity
{
    public ProductType Type { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public DateTime CreatedAt { get; }
    public DateTime? ModifiedAt { get; }

    private Product() { }

    private Product(Guid id, ProductType type, string name, decimal price)
    {
        Id = id;
        Type = type;
        Name = name;
        Price = price;
    }

    public static Product Create(ProductType type, string name, decimal price)
        => new(Guid.NewGuid(), type, name, price);

}
