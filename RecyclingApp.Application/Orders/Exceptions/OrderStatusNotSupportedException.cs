using RecyclingApp.Domain.Model.Orders;
using System;
using OrderStatusContract = RecyclingApp.Application.Orders.Models.OrderStatus;

namespace RecyclingApp.Application.Orders.Exceptions;

internal class OrderStatusNotSupportedException : Exception
{
    public string Value { get; }

    public OrderStatusNotSupportedException(string value)
        : base($"OrderStatus {value} is not supported.")
        => Value = value;

    public static OrderStatusNotSupportedException Create(OrderStatus entity)
        => new(entity.ToString());

    public static OrderStatusNotSupportedException Create(OrderStatusContract contract)
        => new(contract.ToString());
}
