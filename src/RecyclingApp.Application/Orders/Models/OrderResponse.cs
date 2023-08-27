using System;
using System.Collections.Generic;

namespace RecyclingApp.Application.Orders.Models;

public class OrderResponse
{
    public OrderStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public IEnumerable<OrderItemDto>? OrderItems { get; set; }
}