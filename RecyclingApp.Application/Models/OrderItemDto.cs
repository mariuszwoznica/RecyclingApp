using RecyclingApp.Domain.Model.Products;

namespace RecyclingApp.Application.Models
{
    public class OrderItemDto
    {
        public ProductType ProductType { get; set; }
        public int Quantity { get; set; }
    }
}
