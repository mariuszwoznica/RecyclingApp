using MediatR;
using RecyclingApp.Application.Models;
using RecyclingApp.Application.Wrappers;
using System;
using System.Collections.Generic;

namespace RecyclingApp.Application.Orders.Commands;

public record CreateOrder(
    IReadOnlyCollection<Guid> ProductIds,
    IReadOnlyCollection<int> Quantity) : IRequest<Response<OrderCreatedDto>>;