using RecyclingApp.Domain.Entities.Products;

namespace RecyclingApp.Application.Orders.Models;

public class OrderItemDto
{
    public ProductType ProductType { get; set; }
    public int Quantity { get; set; }
}
