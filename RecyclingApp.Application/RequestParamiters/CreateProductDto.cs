using RecyclingApp.Application.Products.Models;

namespace RecyclingApp.Application.RequestParamiters;

public record CreateProductDto(
    ProductType Type,
    string Name,
    decimal Price);
