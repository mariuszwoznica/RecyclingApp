using MediatR;
using RecyclingApp.Application.Models;
using RecyclingApp.Application.Wrappers;

namespace RecyclingApp.Application.Orders.Commands;

public record CreateOrderCommand(string Name) : IRequest<Response<OrderCreatedDto>>;