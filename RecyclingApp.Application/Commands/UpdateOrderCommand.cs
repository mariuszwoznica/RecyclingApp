﻿using AutoMapper;
using MediatR;
using RecyclingApp.Application.Models;
using RecyclingApp.Application.Wrappers;
using RecyclingApp.Domain.Interfaces;
using RecyclingApp.Domain.Model;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Application.Commands
{
    public class UpdateOrderCommand : IRequest<Response<OrderDto>>
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public UpdateOrderCommand(Guid id, Guid productId, int quantity)
        {
            Id = id;
            ProductId = productId;
            Quantity = quantity;
        }
    }
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Response<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository, IRepository<Product> productRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Response<OrderDto>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.ProductId);
            var order = await _orderRepository.GetWithItemsAsync(request.Id);

            if (product != null && order != null)
            {
                order.AddItem(request.Id, request.ProductId, request.Quantity);
                _orderRepository.Update(order);
                await _orderRepository.SaveChangesAsync();

                return new Response<OrderDto>(_mapper.Map<OrderDto>(order));
            }
            else
                throw new ArgumentException();

        }

    }
}
