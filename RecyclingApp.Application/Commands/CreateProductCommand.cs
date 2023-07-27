using AutoMapper;
using MediatR;
using RecyclingApp.Application.Models;
using RecyclingApp.Application.Wrappers;
using RecyclingApp.Domain.Interfaces;
using RecyclingApp.Domain.Model;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Application.Commands
{
    public class CreateProductCommand : IRequest<Response<ProductDto>>
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public CreateProductCommand(string type, string name, int price)
        {
            Type = type;
            Name = name;
            Price = price;
        }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Response<ProductDto>>
        {
            private readonly IRepository<Product> _productRepository;
            private readonly IMapper _mapper;

            public CreateProductCommandHandler(IRepository<Product> productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<Response<ProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = Product.Create(request.Type, request.Name, request.Price);
                _productRepository.Add(product);
                await _productRepository.SaveChangesAsync();

                return new Response<ProductDto>(_mapper.Map<ProductDto>(product));
            }

        }
    }
}
