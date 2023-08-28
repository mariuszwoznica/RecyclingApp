using MediatR;
using RecyclingApp.Application.Products.Commands;
using RecyclingApp.Domain.Entities.Products;
using RecyclingApp.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Application.Products.Handlers.Commands;

internal class DeleteProductCommandHandler : IRequestHandler<DeleteProduct>
{
    private readonly IRepository<Product> _repository;

    public DeleteProductCommandHandler(IRepository<Product> repository)
        => _repository = repository;

    public async Task Handle(DeleteProduct request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetAsync(id: request.ProductId);

        if (product is null)
            return;

        _repository.Delete(product);
        await _repository.SaveChangesAsync();
    }
}
