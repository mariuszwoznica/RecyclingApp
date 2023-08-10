using MediatR;
using RecyclingApp.Application.Products.Commands;
using RecyclingApp.Application.Products.Utilities;
using RecyclingApp.Domain.Interfaces;
using RecyclingApp.Domain.Model.Products;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Application.Products.Handlers.Commands;

internal class CreateProductCommandHandler : IRequestHandler<CreateProduct>
{
    private readonly IRepository<Product> _productRepository;

    public CreateProductCommandHandler(IRepository<Product> productRepository)
        => _productRepository = productRepository;

    public async Task Handle(CreateProduct request, CancellationToken cancellationToken)
    {
        var product = Product.Create(type: request.Type.ToEntity(), name: request.Name, price: request.Price);
        _productRepository.Add(entity: product);
        await _productRepository.SaveChangesAsync();
    }
}