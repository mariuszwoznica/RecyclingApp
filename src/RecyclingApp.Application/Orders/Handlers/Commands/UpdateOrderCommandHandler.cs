using MediatR;
using RecyclingApp.Application.Orders.Commands;
using RecyclingApp.Application.Orders.Exceptions;
using RecyclingApp.Application.Orders.Searchers;
using RecyclingApp.Application.Products.Exceptions;
using RecyclingApp.Application.Products.Searchers;
using RecyclingApp.Domain.Entities.Orders;
using RecyclingApp.Domain.Repositories;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Application.Orders.Handlers.Commands;

internal class UpdateOrderCommandHandler : IRequestHandler<UpdateOrder>
{
    private readonly IRepository<Order> _repository;
    private readonly IOrderSearcher _orderSearcher;
    private readonly IProductSearcher _productSearcher;

    public UpdateOrderCommandHandler(
        IRepository<Order> repository,
        IOrderSearcher orderSearcher,
        IProductSearcher productSearcher)
    {
        _repository = repository;
        _orderSearcher = orderSearcher;
        _productSearcher = productSearcher;
    }

    public async Task Handle(UpdateOrder request, CancellationToken cancellationToken)
    {
        var order = await _orderSearcher.GetWithItemsAsync(id: request.OrderId);
        if (order is null)
            throw new OrderDoesNotExistsException(request.OrderId);

        var products = await _productSearcher.GetByIdsAsync(productIds: request.ProductIds, cancellationToken: cancellationToken);
        if (products.Count != request.ProductIds.Count)
            throw new ProductDoesNotExistsException();

        foreach (var item in order.OrderItems)
            order.RemoveItem(item);

        for (int i = 0; i < request.ProductIds.Count; i++)
            order.AddItem(
                orderId: request.OrderId, 
                productId: request.ProductIds.ElementAt(i), 
                quantity: request.Quantity.ElementAt(i));

        _repository.Update(entity: order);
        await _repository.SaveChangesAsync();
    }
}
