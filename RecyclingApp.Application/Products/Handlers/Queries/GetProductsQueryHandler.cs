using AutoMapper;
using MediatR;
using RecyclingApp.Application.Models;
using RecyclingApp.Application.Products.Queries;
using RecyclingApp.Application.Products.Searchers;
using RecyclingApp.Application.Wrappers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Application.Products.Handlers.Queries;

internal class GetProductsQueryHandler : IRequestHandler<GetProducts, Response<IReadOnlyCollection<ProductDto>>>
{
    private readonly IProductSearcher _searcher;
    private readonly IMapper _mapper;

    public GetProductsQueryHandler(IProductSearcher searcher, IMapper mapper)
    {
        _searcher = searcher;
        _mapper = mapper;
    }

    public async Task<Response<IReadOnlyCollection<ProductDto>>> Handle(GetProducts request, CancellationToken cancellationToken)
    {
        var result = await _searcher.GetList(query: request, cancellationToken: cancellationToken);

        return new PageResponse<IReadOnlyCollection<ProductDto>>(_mapper.Map<IReadOnlyCollection<ProductDto>>(result), result.Data.Count);
    }
}
