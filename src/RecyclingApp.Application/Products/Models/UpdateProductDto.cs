namespace RecyclingApp.Application.Products.Models;

public record UpdateProductDto(
    ProductType Type,
    string Name,
    decimal Price);
