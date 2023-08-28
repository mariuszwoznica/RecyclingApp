using MediatR;
using RecyclingApp.Application.Abstractions;
using RecyclingApp.Application.Exceptions;
using RecyclingApp.Application.Products.Models;
using RecyclingApp.Application.Products.Queries;
using RecyclingApp.Domain.Entities.Products;
using RecyclingApp.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Application.Products.Handlers.Queries;

internal class GetProductQueryHandler : IRequestHandler<GetProduct, ProductResponse>
{
    private readonly IRepository<Product> _repository;
    private readonly IResponseBuilder<Product, ProductResponse> _responseBuilder;

    public GetProductQueryHandler(IRepository<Product> repository, IResponseBuilder<Product, ProductResponse> responseBuilder)
    {
        _repository = repository;
        _responseBuilder = responseBuilder;
    }

    public async Task<ProductResponse> Handle(GetProduct request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetAsync(id: request.ProductId);

        if (result is null)
            throw new EntityNotFoundException(entityId: request.ProductId);

        return _responseBuilder.Build(input: result);
    }
}
