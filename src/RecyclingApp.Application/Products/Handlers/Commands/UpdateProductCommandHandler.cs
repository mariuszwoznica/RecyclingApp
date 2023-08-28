using MediatR;
using RecyclingApp.Application.Exceptions;
using RecyclingApp.Application.Products.Commands;
using RecyclingApp.Application.Products.Utilities;
using RecyclingApp.Domain.Entities.Products;
using RecyclingApp.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Application.Products.Handlers.Commands;

internal class UpdateProductCommandHandler : IRequestHandler<UpdateProduct>
{
    private readonly IRepository<Product> _repository;

    public UpdateProductCommandHandler(IRepository<Product> repository)
        => _repository = repository;

    public async Task Handle(UpdateProduct request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetAsync(id: request.ProductId);

        if (product is null)
            throw new EntityNotFoundException(entityId: request.ProductId);

        product.Update(
            type: request.Type.ToEntity(), 
            name: request.Name, 
            price: request.Price);

        _repository.Update(entity: product);
        await _repository.SaveChangesAsync();
    }
}
