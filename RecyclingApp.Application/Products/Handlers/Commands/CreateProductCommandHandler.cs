using AutoMapper;
using MediatR;
using RecyclingApp.Application.Models;
using RecyclingApp.Application.Products.Commands;
using RecyclingApp.Application.Products.Utilities;
using RecyclingApp.Application.Wrappers;
using RecyclingApp.Domain.Interfaces;
using RecyclingApp.Domain.Model.Products;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Application.Products.Handlers.Commands;

internal class CreateProductCommandHandler : IRequestHandler<CreateProduct, Response<ProductDto>>
{
    private readonly IRepository<Product> _productRepository;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IRepository<Product> productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<Response<ProductDto>> Handle(CreateProduct request, CancellationToken cancellationToken)
    {
        var product = Product.Create(type: request.Type.ToEntity(), name: request.Name, price: request.Price);
        _productRepository.Add(entity: product);
        await _productRepository.SaveChangesAsync();

        return new Response<ProductDto>(_mapper.Map<ProductDto>(product));
    }
}