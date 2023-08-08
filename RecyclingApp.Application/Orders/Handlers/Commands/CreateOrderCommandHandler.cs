using AutoMapper;
using MediatR;
using RecyclingApp.Application.Exceptions;
using RecyclingApp.Application.Models;
using RecyclingApp.Application.Orders.Commands;
using RecyclingApp.Application.Products.Searchers;
using RecyclingApp.Application.Wrappers;
using RecyclingApp.Domain.Interfaces;
using RecyclingApp.Domain.Model.Orders;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Application.Orders.Handlers.Commands;

internal class CreateOrderCommandHandler : IRequestHandler<CreateOrder, Response<OrderCreatedDto>>
{
    private readonly IRepository<Order> _orderRepository;
    private readonly IProductSearcher _productSearcher;
    private readonly IMapper _mapper;

    public CreateOrderCommandHandler(
        IRepository<Order> orderRepository,
        IProductSearcher productSearcher,
        IMapper mapper)
    {
        _orderRepository = orderRepository;
        _productSearcher = productSearcher;
        _mapper = mapper;
    }

    public async Task<Response<OrderCreatedDto>> Handle(CreateOrder request, CancellationToken cancellationToken)
    {
        var products = await _productSearcher.GetByIds(productIds: request.ProductIds, cancellationToken: cancellationToken);
        if (products.Count != request.ProductIds.Count)
            throw new ProductDoesNotExistsException();

        var order = Order.Create();
        for (int i = 0; i < request.ProductIds.Count; i++)
            order.AddItem(
                productId: request.ProductIds.ElementAt(i),
                quantity: request.Quantity.ElementAt(i));

        _orderRepository.Add(entity: order);
        await _orderRepository.SaveChangesAsync();

        return new Response<OrderCreatedDto>(_mapper.Map<OrderCreatedDto>(order));
    }
}
