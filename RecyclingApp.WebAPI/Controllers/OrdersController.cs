using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecyclingApp.Application.Models;
using RecyclingApp.Application.Orders;
using RecyclingApp.Application.Orders.Commands;
using RecyclingApp.Application.Orders.Queries;
using RecyclingApp.Application.RequestParamiters;
using RecyclingApp.Application.Wrappers;
using System;
using System.Collections.Generic;
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
    [ProducesResponseType(typeof(PageResponse<IReadOnlyCollection<OrderDto>>), StatusCodes.Status200OK)]
    public async Task<PageResponse<IReadOnlyCollection<OrderDto>>> GetOrders(
        [FromQuery] int pageNumber,
        [FromQuery] int pageSize,
        [FromQuery] OrderStatusContract? orderStatus,
        [FromQuery] DateTime? minCreatedAt,
        [FromQuery] DateTime? maxCreatedAt,
        [FromQuery] string[]? sorting,
        CancellationToken cancellationToken)
        => await _mediator.Send(
            request: new GetOrders(
                Page: pageNumber,
                Limit: pageSize,
                Status: orderStatus,
                MinCreatedAt: minCreatedAt,
                MaxCreatedAt: maxCreatedAt,
                Sorting: sorting),
            cancellationToken: cancellationToken);

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto data, CancellationToken cancellationToken)
    {
        var request = new CreateOrder(
            ProductIds: data.ProductIds,
            Quantity: data.Quantity
        );
        var order = await _mediator.Send(request: request, cancellationToken: cancellationToken);
        return Created(string.Empty, order);
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