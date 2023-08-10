using MediatR;
using RecyclingApp.Application.Orders.Commands;
using RecyclingApp.Application.Orders.Exceptions;
using RecyclingApp.Application.Products.Exceptions;
using RecyclingApp.Application.Products.Searchers;
using RecyclingApp.Domain.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Application.Orders.Handlers.Commands;

internal class UpdateOrderCommandHandler : IRequestHandler<UpdateOrder>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductSearcher _productSearcher;

    public UpdateOrderCommandHandler(
        IOrderRepository orderRepository,
        IProductSearcher productSearcher)
    {
        _orderRepository = orderRepository;
        _productSearcher = productSearcher;
    }

    public async Task Handle(UpdateOrder request, CancellationToken cancellationToken)
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
    }
}
