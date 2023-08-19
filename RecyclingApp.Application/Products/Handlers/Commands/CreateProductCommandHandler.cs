using MediatR;
using RecyclingApp.Application.Products.Commands;
using RecyclingApp.Application.Products.Utilities;
using RecyclingApp.Domain.Entities.Products;
using RecyclingApp.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Application.Products.Handlers.Commands;

internal class CreateProductCommandHandler : IRequestHandler<CreateProduct>
{
    private readonly IRepository<Product> _repository;

    public CreateProductCommandHandler(IRepository<Product> repository)
        => _repository = repository;

    public async Task Handle(CreateProduct request, CancellationToken cancellationToken)
    {
        var product = Product.Create(type: request.Type.ToEntity(), name: request.Name, price: request.Price);
        _repository.Add(entity: product);
        await _repository.SaveChangesAsync();
    }
}