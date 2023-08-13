using MediatR;
using RecyclingApp.Application.Models;
using RecyclingApp.Application.Orders.Models;
using RecyclingApp.Application.Orders.Queries;
using RecyclingApp.Application.Orders.Searchers;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Application.Orders.Handlers.Queries;

internal class GetOrdersQueryHandler : IRequestHandler<GetOrders, PagedResponse<OrderResponse>>
{
    private readonly IOrderSearcher _searcher;

    public GetOrdersQueryHandler(IOrderSearcher searcher)
        => _searcher = searcher;

    public async Task<PagedResponse<OrderResponse>> Handle(GetOrders request, CancellationToken cancellationToken)
        => await _searcher.GetList(query: request, cancellationToken: cancellationToken);
}