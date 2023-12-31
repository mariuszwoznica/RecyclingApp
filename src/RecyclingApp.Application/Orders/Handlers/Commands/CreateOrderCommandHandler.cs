﻿using MediatR;
using RecyclingApp.Application.Orders.Commands;
using RecyclingApp.Application.Products.Exceptions;
using RecyclingApp.Application.Products.Searchers;
using RecyclingApp.Domain.Entities.Orders;
using RecyclingApp.Domain.Repositories;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Application.Orders.Handlers.Commands;

internal class CreateOrderCommandHandler : IRequestHandler<CreateOrder>
{
    private readonly IRepository<Order> _repository;
    private readonly IProductSearcher _productSearcher;

    public CreateOrderCommandHandler(
        IRepository<Order> repository,
        IProductSearcher productSearcher)
    {
        _repository = repository;
        _productSearcher = productSearcher;
    }

    public async Task Handle(CreateOrder request, CancellationToken cancellationToken)
    {
        var products = await _productSearcher.GetByIdsAsync(productIds: request.ProductIds, cancellationToken: cancellationToken);
        if (products.Count != request.ProductIds.Count)
            throw new ProductDoesNotExistsException();

        var order = Order.Create();
        for (int i = 0; i < request.ProductIds.Count; i++)
            order.AddItem(
                productId: request.ProductIds.ElementAt(i),
                quantity: request.Quantities.ElementAt(i));

        _repository.Add(entity: order);
        await _repository.SaveChangesAsync();
    }
}
