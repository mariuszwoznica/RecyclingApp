using AutoMapper;
using MediatR;
using RecyclingApp.Application.Exceptions;
using RecyclingApp.Application.Models;
using RecyclingApp.Application.Orders.Commands;
using RecyclingApp.Application.Orders.Exceptions;
using RecyclingApp.Application.Products.Searchers;
using RecyclingApp.Application.Wrappers;
using RecyclingApp.Domain.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Application.Orders.Handlers.Commands;

internal class UpdateOrderCommandHandler : IRequestHandler<UpdateOrder, Response<OrderDto>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductSearcher _productSearcher;
    private readonly IMapper _mapper;

    public UpdateOrderCommandHandler(
        IOrderRepository orderRepository,
        IProductSearcher productSearcher,
        IMapper mapper)
    {
        _orderRepository = orderRepository;
        _productSearcher = productSearcher;
        _mapper = mapper;
    }

    public async Task<Response<OrderDto>> Handle(UpdateOrder request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetWithItemsAsync(id: request.OrderId);
        if (order is null)
            throw new OrderDoesNotExistsException(request.OrderId);

        var products = await _productSearcher.GetByIds(productIds: request.ProductIds, cancellationToken: cancellationToken);
        if (products.Count != request.ProductIds.Count)
            throw new ProductDoesNotExistsException();

        foreach (var item in order.OrderItems)
            order.RemoveItem(item);

        for (int i = 0; i < request.ProductIds.Count; i++)
            order.AddItem(
                orderId: request.OrderId, 
                productId: request.ProductIds.ElementAt(i), 
                quantity: request.Quantity.ElementAt(i));

        _orderRepository.Update(entity: order);
        await _orderRepository.SaveChangesAsync();

        return new Response<OrderDto>(_mapper.Map<OrderDto>(order));
    }
}
