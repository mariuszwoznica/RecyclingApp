using Microsoft.EntityFrameworkCore;
using RecyclingApp.Application.Abstractions;
using RecyclingApp.Application.Orders.Models;
using RecyclingApp.Application.Orders.Queries;
using RecyclingApp.Application.Orders.Utilities;
using RecyclingApp.Application.Pagination;
using RecyclingApp.Application.Utilities;
using RecyclingApp.Domain.Entities.Orders;
using RecyclingApp.Domain.Entities.Products;
using System;
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
        _query = context.Set<Order>().AsNoTracking();
        _productQuery = context.Set<Product>().AsNoTracking();
    }

    public async Task<PagedResponse<OrderResponse>> GetListAsync(GetOrders query, CancellationToken cancellationToken)
        => await _query
            .Where(o => !query.Status.HasValue || o.Status.Equals(query.Status))
            .ApplyCreatedAtFilter(minCreatedAt: query.MinCreatedAt, maxCreatedAt: query.MaxCreatedAt) 
            .ApplySorting(sortingParams: query.Sorting)
            .Select(o => new OrderResponse()
            {
                Status = o.Status.ToContract(),
                CreatedAt = o.CreatedAt,
                OrderItems = o.OrderItems
                    .Where(i => i.OrderId == o.Id)
                    .Join(_productQuery, i => i.ProductId, p => p.Id,
                        (i, p) => new OrderItemDto { ProductType = p.Type, Quantity = i.Quantity }),
            })
            .TakePageAsync(pageNumber: query.Page, pageSize: query.PageSize, cancellationToken: cancellationToken);

    public async Task<Order?> GetWithItemsAsync(Guid id)
        => await _query
            .Include(o => o.OrderItems)
            .SingleOrDefaultAsync(o => o.Id == id);
}
