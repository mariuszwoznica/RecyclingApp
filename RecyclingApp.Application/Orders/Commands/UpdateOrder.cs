using MediatR;
using System;
using System.Collections.Generic;

namespace RecyclingApp.Application.Orders.Commands;

public record UpdateOrder(
    Guid OrderId,
    IReadOnlyCollection<Guid> ProductIds,
    IReadOnlyCollection<int> Quantity) : IRequest;