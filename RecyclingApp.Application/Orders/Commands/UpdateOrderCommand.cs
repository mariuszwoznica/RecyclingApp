using MediatR;
using RecyclingApp.Application.Models;
using RecyclingApp.Application.Wrappers;
using System;

namespace RecyclingApp.Application.Orders.Commands;

public record UpdateOrderCommand(
    Guid Id, 
    Guid ProductId, 
    int Quantity) : IRequest<Response<OrderDto>>;