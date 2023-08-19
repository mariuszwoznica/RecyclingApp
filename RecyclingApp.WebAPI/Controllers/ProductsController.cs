using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecyclingApp.Application.Models;
using RecyclingApp.Application.Products.Commands;
using RecyclingApp.Application.Products.Models;
using RecyclingApp.Application.Products.Queries;
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
    [ProducesResponseType(typeof(PagedResponse<ProductResponse>), StatusCodes.Status200OK)]
    public async Task<PagedResponse<ProductResponse>> GetProducts(
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
        await _mediator.Send(
            request: new CreateProduct(
                Type: data.Type,
                Name: data.Name,
                Price: data.Price),
            cancellationToken: cancellationToken);
        return Created(string.Empty, cancellationToken);
    }
}
