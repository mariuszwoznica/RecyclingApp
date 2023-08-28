using RecyclingApp.Application.Orders.Models;
using RecyclingApp.Application.Orders.Queries;
using RecyclingApp.Application.Pagination;
using RecyclingApp.Domain.Entities.Orders;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Application.Orders.Searchers;

internal interface IOrderSearcher
{
    Task<PagedResponse<OrderResponse>> GetListAsync(GetOrders query, CancellationToken cancellationToken);
    Task<Order?> GetWithItemsAsync(Guid id);
}