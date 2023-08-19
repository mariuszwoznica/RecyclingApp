using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecyclingApp.Application.Orders.Commands;
using RecyclingApp.Application.Orders.Models;
using RecyclingApp.Application.Orders.Queries;
using RecyclingApp.Application.Pagination;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
        => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(typeof(PagedResponse<OrderResponse>), StatusCodes.Status200OK)]
    public async Task<PagedResponse<OrderResponse>> GetOrders(
        [FromQuery] int pageNumber,
        [FromQuery] int pageSize,
        [FromQuery] OrderStatus? orderStatus,
        [FromQuery] DateTime? minCreatedAt,
        [FromQuery] DateTime? maxCreatedAt,
        [FromQuery] string[]? sorting,
        CancellationToken cancellationToken)
        => await _mediator.Send(
            request: new GetOrders(
                Page: pageNumber,
                PageSize: pageSize,
                Status: orderStatus,
                MinCreatedAt: minCreatedAt,
                MaxCreatedAt: maxCreatedAt,
                Sorting: sorting),
            cancellationToken: cancellationToken);

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto data, CancellationToken cancellationToken)
    {
        await _mediator.Send(
            request: new CreateOrder(
                ProductIds: data.ProductIds,
                Quantity: data.Quantity),
            cancellationToken: cancellationToken);
        return Created(string.Empty, cancellationToken);
    }

    [HttpPut("{orderId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateOrder(
        [FromRoute] Guid orderId, 
        UpdateOrderDto data,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(
            request: new UpdateOrder(
                OrderId: orderId,
                ProductIds: data.ProductIds,
                Quantity: data.Quantity),
            cancellationToken: cancellationToken);
        return NoContent();
    }
}