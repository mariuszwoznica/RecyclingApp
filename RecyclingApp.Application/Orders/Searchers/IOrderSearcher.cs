using RecyclingApp.Application.Models;
using RecyclingApp.Application.Orders.Models;
using RecyclingApp.Application.Orders.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Application.Orders.Searchers;

internal interface IOrderSearcher
{
    Task<PagedResponse<OrderResponse>> GetList(GetOrders query, CancellationToken cancellationToken);
}