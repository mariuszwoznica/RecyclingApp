using MediatR;
using RecyclingApp.Application.Models;
using RecyclingApp.Application.Wrappers;
using System;
using System.Collections.Generic;

namespace RecyclingApp.Application.Orders.Queries;

public record GetOrders(
    int Page, 
    int Limit,
    OrderStatusContract? Status,
    DateTime? MinCreatedAt, 
    DateTime? MaxCreatedAt,
    string[]? Sorting) : IRequest<PageResponse<IReadOnlyCollection<OrderDto>>>;