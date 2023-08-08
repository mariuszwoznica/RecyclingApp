using RecyclingApp.Domain.Common;
using System;
using System.Collections.Generic;

namespace RecyclingApp.Domain.Model.Orders;

public class Order : BaseEntity, IAuditable
{
    public OrderStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public ICollection<OrderItem> OrderItems { get; private set; }

    private Order() { }

    private Order(Guid id)
    {
        Id = id;
        Status = OrderStatus.Open;
    }

    public static Order Create()
        => new(Guid.NewGuid());

    public void AddItem(Guid productId, int quantity, Guid? orderId = null)
    {
        OrderItems ??= new List<OrderItem>();
        OrderItems.Add(new OrderItem(
            orderId: orderId ?? this.Id, 
            productId: productId, 
            quantity: quantity));
    }

    public void RemoveItem(OrderItem item)
        => OrderItems.Remove(item);

    public void MarkAsInTransit()
        => Status = OrderStatus.InTransit;

    public void MarkAsClosed()
        => Status = OrderStatus.Closed;
}
