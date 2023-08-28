using MediatR;
using RecyclingApp.Application.Products.Models;
using System;

namespace RecyclingApp.Application.Products.Commands;

public record UpdateProduct(
    Guid ProductId,
    ProductType Type, 
    string Name, 
    decimal Price) : IRequest;
