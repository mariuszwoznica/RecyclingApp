using MediatR;
using RecyclingApp.Application.Models;
using RecyclingApp.Application.Wrappers;
using System;
using System.Collections.Generic;

namespace RecyclingApp.Application.Orders.Queries;

public record GetAllOrdersQuery(
    int Page, 
    int Limit, 
    string Name, 
    string Status, 
    DateTime MinCreatedAt, 
    DateTime MaxCreatedAt,
    int MinProductCount, 
    int MaxProductCount, 
    string OrderBy) : IRequest<Response<IEnumerable<OrderDto>>>;