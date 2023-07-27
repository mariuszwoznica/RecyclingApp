using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecyclingApp.Application.Commands;
using RecyclingApp.Application.Queries;
using RecyclingApp.Application.RequestParamiters;
using System;
using System.Threading.Tasks;

namespace RecyclingApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders([FromQuery] GetOrdersRequest request)
        {
            return Ok(await _mediator.Send(new GetAllOrdersQuery(request.Page, request.Limit, request.Name, request.Status,
                request.MinCreatedAt, request.MaxCreatedAt, request.MinProductCount, request.MaxProductCount, request.OrderBy)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
        {
            var order = Ok(await _mediator.Send(new CreateOrderCommand(request.Name)));
            return Created(string.Empty, order);
        }

        //Provides ability to add products to order and update totalItems column in Orders table.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(Guid id, UpdateOrderRequest request)
        {
            return Ok(await _mediator.Send(new UpdateOrderCommand(id, request.ProductId, request.Quantity)));
        }

    }
}
