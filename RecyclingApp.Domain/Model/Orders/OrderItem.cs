using System;

namespace RecyclingApp.Domain.Model.Orders;

public class OrderItem
{
    public Guid OrderId { get; private set; }
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }

    private OrderItem() { }

    public OrderItem(Guid orderId, Guid productId, int quantity)
    {
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
    }
}
