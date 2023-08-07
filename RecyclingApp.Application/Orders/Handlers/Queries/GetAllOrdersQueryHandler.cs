using MediatR;
using RecyclingApp.Application.Models;
using RecyclingApp.Application.Orders.Queries;
using RecyclingApp.Application.Orders.Searchers;
using RecyclingApp.Application.Wrappers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Application.Orders.Handlers.Queries;

internal class GetAllOrdersQueryHandler : IRequestHandler<GetOrders, PageResponse<IReadOnlyCollection<OrderDto>>>
{
    private readonly IOrderSearcher _searcher;

    public GetAllOrdersQueryHandler(IOrderSearcher searcher)
        => _searcher = searcher;

    public async Task<PageResponse<IReadOnlyCollection<OrderDto>>> Handle(GetOrders request, CancellationToken cancellationToken)
    {
        var result = await _searcher.GetList(query: request, cancellationToken: cancellationToken);

        return new PageResponse<IReadOnlyCollection<OrderDto>>(result.Data, result.Data.Count);
    }
}