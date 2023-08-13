using MediatR;
using RecyclingApp.Application.Models;
using RecyclingApp.Application.Products.Models;

namespace RecyclingApp.Application.Products.Queries;

public record GetProducts(
    int Page,
    int PageSize,
    string? Name,
    ProductType? Type,
    decimal? MinPrice,
    decimal? MaxPrice,
    string[]? Sorting) : IRequest<PagedResponse<ProductResponse>>;