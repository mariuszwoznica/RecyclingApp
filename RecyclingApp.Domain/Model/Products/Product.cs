using RecyclingApp.Domain.Common;
using System;

namespace RecyclingApp.Domain.Model.Products;

public class Product : BaseEntity, IAuditable
{
    public ProductType Type { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }

    private Product() { }

    private Product(Guid id, ProductType type, string name, decimal price)
    {
        Id = id;
        Type = type;
        Name = name;
        Price = price;
    }

    public static Product Create(ProductType type, string name, decimal price)
        => new Product(Guid.NewGuid(), type, name, price);

}
