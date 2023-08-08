using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecyclingApp.Application.Models;
using RecyclingApp.Application.Products.Commands;
using RecyclingApp.Application.Products.Models;
using RecyclingApp.Application.Products.Queries;
using RecyclingApp.Application.RequestParamiters;
using RecyclingApp.Application.Wrappers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
        => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(typeof(PageResponse<IReadOnlyCollection<ProductDto>>), StatusCodes.Status200OK)]
    public async Task<PageResponse<IReadOnlyCollection<ProductDto>>> GetProducts(
        [FromQuery] int pageNumber,
        [FromQuery] int pageSize,
        [FromQuery] string? name,
        [FromQuery] ProductType? type,
        [FromQuery] decimal? minPrice,
        [FromQuery] decimal? maxPrice,
        [FromQuery] string[]? sorting,
        CancellationToken cancellationToken)
        => await _mediator.Send(
            request: new GetProducts(
                Page: pageNumber,
                PageSize: pageSize,
                Type: type,
                Name: name,
                MinPrice: minPrice,
                MaxPrice: maxPrice,
                Sorting: sorting),
            cancellationToken: cancellationToken);

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto data, CancellationToken cancellationToken)
    {
        var product = await _mediator.Send(
            request: new CreateProduct(
                Type: data.Type,
                Name: data.Name,
                Price: data.Price),
            cancellationToken: cancellationToken);
        return Created(string.Empty, product);
    }
}
