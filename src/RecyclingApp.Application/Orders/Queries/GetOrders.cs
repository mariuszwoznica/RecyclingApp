using MediatR;
using RecyclingApp.Application.Orders.Models;
using RecyclingApp.Application.Pagination;
using System;

namespace RecyclingApp.Application.Orders.Queries;

public record GetOrders(
    int Page, 
    int PageSize,
    OrderStatus? Status,
    DateTime? MinCreatedAt, 
    DateTime? MaxCreatedAt,
    string[]? Sorting) : IRequest<PagedResponse<OrderResponse>>;