using System;

namespace RecyclingApp.Application.Orders.Exceptions;

internal class OrderDoesNotExistsException : Exception
{
    public Guid OrderId { get; }

    public OrderDoesNotExistsException(Guid orderId)
        : base($"Order {orderId} does not exist.")
        => OrderId = orderId;
}
