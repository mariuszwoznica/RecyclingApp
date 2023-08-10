using MediatR;
using System;
using System.Collections.Generic;

namespace RecyclingApp.Application.Orders.Commands;

public record CreateOrder(
    IReadOnlyCollection<Guid> ProductIds,
    IReadOnlyCollection<int> Quantity) : IRequest;