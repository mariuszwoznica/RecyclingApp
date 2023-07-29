using RecyclingApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecyclingApp.Domain.Model.Orders;

public class Order : BaseEntity, IAuditable
{
    public string Name { get; private set; }
    public OrderStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public int TotalItems { get; private set; }
    public ICollection<OrderItem> OrderItems { get; private set; }

    private Order() { }

    public Order(string name)
    {
        Name = name;
        Status = OrderStatus.Open;
    }

    public static Order Create(string name)
        => new Order(name);

    public void AddItem(Guid orderId, Guid productId, int quantity)
    {
        OrderItems.Add(new OrderItem(orderId, productId, quantity));
        TotalItems = OrderItems.Sum(i => i.Quantity);
    }

}
