using MediatR;
using RecyclingApp.Application.Products.Models;

namespace RecyclingApp.Application.Products.Commands;

public record CreateProduct(
     ProductType Type,
     string Name,
     decimal Price) : IRequest;
