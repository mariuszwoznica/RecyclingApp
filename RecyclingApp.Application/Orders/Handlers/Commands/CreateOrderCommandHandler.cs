using AutoMapper;
using MediatR;
using RecyclingApp.Application.Models;
using RecyclingApp.Application.Orders.Commands;
using RecyclingApp.Application.Wrappers;
using RecyclingApp.Domain.Interfaces;
using RecyclingApp.Domain.Model.Orders;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Application.Orders.Handlers.Commands;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<OrderCreatedDto>>
{
    private readonly IRepository<Order> _orderRepository;
    private readonly IMapper _mapper;

    public CreateOrderCommandHandler(IRepository<Order> orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<Response<OrderCreatedDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = Order.Create(request.Name);
        _orderRepository.Add(order);
        await _orderRepository.SaveChangesAsync();

        return new Response<OrderCreatedDto>(_mapper.Map<OrderCreatedDto>(order));
    }
}
