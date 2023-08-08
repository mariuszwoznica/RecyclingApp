using Microsoft.EntityFrameworkCore;
using RecyclingApp.Application.Helpers;
using RecyclingApp.Application.Interfaces;
using RecyclingApp.Application.Models;
using RecyclingApp.Application.Orders.Queries;
using RecyclingApp.Application.Orders.Utilities;
using RecyclingApp.Application.Wrappers;
using RecyclingApp.Domain.Model.Orders;
using RecyclingApp.Domain.Model.Products;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Application.Orders.Searchers;

internal class OrderSearcher : IOrderSearcher
{
    private readonly IQueryable<Order> _query;
    private readonly IQueryable<Product> _productQuery;

    public OrderSearcher(IApplicationDbContext context)
    {
        _query = context.Set<Order>();
        _productQuery = context.Set<Product>();
    }

    public async Task<PageResponse<IReadOnlyCollection<OrderDto>>> GetList(GetOrders query, CancellationToken cancellationToken)
    {
        var orders = await _query
            .Where(o => !query.Status.HasValue || o.Status.Equals(query.Status))
            .ApplyCreatedAtFilter(minCreatedAt: query.MinCreatedAt, maxCreatedAt: query.MaxCreatedAt) 
            .ApplySorting(sortingParams: query.Sorting)
            .Select(o => new OrderDto
            {
                Id = o.Id,
                Status = o.Status.ToString(),
                CreatedAt = o.CreatedAt,
                OrderItems = o.OrderItems
                    .Where(i => i.OrderId == o.Id)
                    .Join(_productQuery, i => i.ProductId, p => p.Id,
                        (i, p) => new OrderItemDto { ProductType = p.Type, Quantity = i.Quantity }),
            })
            .ApplyPaging(page: query.Page, limit: query.Limit)
            .ToListAsync(cancellationToken: cancellationToken);

        return new PageResponse<IReadOnlyCollection<OrderDto>>(orders, orders.Count);
    }
}
