using RecyclingApp.Application.Models;
using RecyclingApp.Application.Orders.Queries;
using RecyclingApp.Application.Wrappers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Application.Orders.Searchers;

internal interface IOrderSearcher
{
    Task<PageResponse<IReadOnlyCollection<OrderDto>>> GetList(GetOrders query, CancellationToken cancellationToken);
}