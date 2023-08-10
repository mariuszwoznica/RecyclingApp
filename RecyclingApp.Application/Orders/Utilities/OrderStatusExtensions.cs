using RecyclingApp.Application.Orders.Exceptions;
using RecyclingApp.Domain.Model.Orders;
using OrderStatusContract = RecyclingApp.Application.Orders.Models.OrderStatus;

namespace RecyclingApp.Application.Orders.Utilities;

internal static class OrderStatusExtensions
{
    internal static OrderStatus ToEntity(this OrderStatusContract contract)
        => contract switch
        {
            OrderStatusContract.Open => OrderStatus.Open,
            OrderStatusContract.InTransit => OrderStatus.InTransit,
            OrderStatusContract.Closed => OrderStatus.Closed,
            _ => throw OrderStatusNotSupportedException.Create(contract)
        };

    internal static OrderStatusContract ToContract(this OrderStatus entity)
        => entity switch
        {
            OrderStatus.Open => OrderStatusContract.Open,
            OrderStatus.InTransit => OrderStatusContract.InTransit,
            OrderStatus.Closed => OrderStatusContract.Closed,
            _ => throw OrderStatusNotSupportedException.Create(entity)
        };
}
