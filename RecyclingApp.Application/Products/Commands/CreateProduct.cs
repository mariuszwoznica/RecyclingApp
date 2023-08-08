using MediatR;
using RecyclingApp.Application.Models;
using RecyclingApp.Application.Products.Models;
using RecyclingApp.Application.Wrappers;

namespace RecyclingApp.Application.Products.Commands;

public record CreateProduct(
     ProductType Type,
     string Name,
     decimal Price) : IRequest<Response<ProductDto>>;
