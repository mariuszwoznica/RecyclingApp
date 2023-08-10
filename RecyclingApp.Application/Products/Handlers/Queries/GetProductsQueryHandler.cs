﻿using MediatR;
using RecyclingApp.Application.Interfaces;
using RecyclingApp.Application.Models;
using RecyclingApp.Application.Products.Models;
using RecyclingApp.Application.Products.Queries;
using RecyclingApp.Application.Products.Searchers;
using RecyclingApp.Domain.Model.Products;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Application.Products.Handlers.Queries;

internal class GetProductsQueryHandler : IRequestHandler<GetProducts, PageResponse<ProductResponse>>
{
    private readonly IProductSearcher _searcher;
    private readonly IResponseBuilder<Product, ProductResponse> _responseBuilder;

    public GetProductsQueryHandler(IProductSearcher searcher, IResponseBuilder<Product, ProductResponse> responseBuilder)
    {
        _searcher = searcher;
        _responseBuilder = responseBuilder;
    }

    public async Task<PageResponse<ProductResponse>> Handle(GetProducts request, CancellationToken cancellationToken)
    {
        var result = await _searcher.GetList(query: request, cancellationToken: cancellationToken);

        return new PageResponse<ProductResponse>(
            results: result.Results.Select(p => _responseBuilder.Build(input: p)).ToList(), 
            pageInfo: result.PageInfo);
    }
}