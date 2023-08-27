namespace RecyclingApp.Application.Products.Models;

public record CreateProductDto(
    ProductType Type,
    string Name,
    decimal Price);
