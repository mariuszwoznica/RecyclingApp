using RecyclingApp.Domain.Common;

namespace RecyclingApp.Domain.Model;

public class Product : BaseEntity, IAuditable
{
    public string Type { get; private set; }
    public string Name { get; private set; }
    public int Price { get; private set; }

    private Product() { }

    public Product(string type, string name, int price)
    {
        Type = type;
        Name = name;
        Price = price;
    }

    public static Product Create(string type, string name, int price)
        => new Product(type, name, price);

}
