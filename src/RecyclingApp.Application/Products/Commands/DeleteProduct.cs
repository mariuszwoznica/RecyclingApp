using MediatR;
using System;

namespace RecyclingApp.Application.Products.Commands;

public record DeleteProduct(Guid ProductId) : IRequest;
