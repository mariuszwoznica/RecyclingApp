using RecyclingApp.Application.Abstractions;
using RecyclingApp.Application.Products.Models;
using RecyclingApp.Application.Products.Utilities;
using RecyclingApp.Domain.Entities.Products;

namespace RecyclingApp.Application.Products.Builders;

internal class ProductResponseBuilder : IResponseBuilder<Product, ProductResponse>
{
    public ProductResponse Build(Product input)
        => new(
            Name: input.Name,
            Type: input.Type.ToContract(),
            Price: input.Price
            );
}