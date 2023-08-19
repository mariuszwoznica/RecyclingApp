using MediatR;
using RecyclingApp.Application.Products.Models;
using System;

namespace RecyclingApp.Application.Products.Queries;

public record GetProduct(Guid ProductId) : IRequest<ProductResponse>;
