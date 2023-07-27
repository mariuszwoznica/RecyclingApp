using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecyclingApp.Application.Commands;
using RecyclingApp.Application.Queries;
using RecyclingApp.Application.RequestParamiters;
using System.Threading.Tasks;

namespace RecyclingApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] GetProductsRequest request)
        {
            return Ok(await _mediator.Send(new GetAllProductsQuery(request.Page, request.Limit, request.Type, request.Name,
                request.MinPrice, request.MaxPrice, request.OrderBy)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
        {
            var product = Ok(await _mediator.Send(new CreateProductCommand(request.Type, request.Name, request.Price)));
            return Created(string.Empty, product);
        }

    }
}
