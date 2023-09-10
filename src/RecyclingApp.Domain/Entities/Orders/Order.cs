using RecyclingApp.Domain.Primitives;
using System;
using System.Collections.Generic;

namespace RecyclingApp.Domain.Entities.Orders;

public class Order : BaseEntity, IAuditableEntity
{
    public Guid CustomerId { get; private set; }
    public OrderStatus Status { get; private set; }
    public ICollection<OrderItem> OrderItems { get; private set; }
    public DateTime CreatedAt { get; }
    public DateTime? ModifiedAt { get; }

    private Order() { }

    private Order(Guid id)
    {
        Id = id;
        Status = OrderStatus.Open;
    }

    public static Order Create()
        => new(Guid.NewGuid());

    public void AddItem(Guid productId, int quantity)
    {
        OrderItems ??= new List<OrderItem>();
        OrderItems.Add(new OrderItem(
            orderId: Id,
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
