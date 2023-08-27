namespace RecyclingApp.Application.Products.Models;

public record ProductResponse(
    string Name,
    ProductType Type,
    decimal Price);