using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RecyclingApp.Application.Filters;
using RecyclingApp.Application.Helpers;
using RecyclingApp.Application.Interfaces;
using RecyclingApp.Application.Models;
using RecyclingApp.Application.Wrappers;
using RecyclingApp.Domain.Model;
using RecyclingApp.Domain.Model.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Application.Queries
{
    public class GetAllOrdersQuery : IRequest<Response<IEnumerable<OrderDto>>>
    {
        public int Page { get; set; }
        public int Limit { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime MinCreatedAt { get; set; }
        public DateTime MaxCreatedAt { get; set; }
        public int MinProductCount { get; set; }
        public int MaxProductCount { get; set; }
        public string OrderBy { get; set; }

        public GetAllOrdersQuery(int page, int limit, string name, string status, DateTime minCreatedAt, DateTime maxCreatedAt,
            int minProductCount, int maxProductCount, string orderBy)
        {
            Page = page;
            Limit = limit;
            Name = name;
            Status = status;
            MinCreatedAt = minCreatedAt;
            MaxCreatedAt = maxCreatedAt;
            MinProductCount = minProductCount;
            MaxProductCount = maxProductCount;
            OrderBy = orderBy;
        }

        public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, Response<IEnumerable<OrderDto>>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetAllOrdersQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Response<IEnumerable<OrderDto>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
            {
                var parameters = _mapper.Map<PaginationFilter>(request);
                var orderParamiters = _mapper.Map<OrderFilters>(request);

                var products = _context.Set<Product>();
                var query = _context.Set<Order>();
                var orders = await query
                    .SearchOrders(orderParamiters)
                    .FilterOrders(orderParamiters)
                    .ApplaySorting(orderParamiters.OrderBy)
                    .ApplayPaging(parameters.Page, parameters.Limit)
                    .Select(o => new OrderDto
                    {
                        Id = o.Id,
                        Name = o.Name,
                        Status = o.Status.ToString(),
                        CreatedAt = o.CreatedAt,
                        OrderItems = o.OrderItems.Where(i => i.OrderId == o.Id).Select(i => new OrderItemDto
                        {
                            ProductType = products.Single(p => p.Id == i.ProductId).Type,
                            Quantity = i.Quantity
                        }),
                        TotalItems = o.TotalItems
                    })
                    .ToListAsync(cancellationToken: cancellationToken);

                return new PagedResponse<IEnumerable<OrderDto>>(orders, orders.Count);
            }

        }
    }
}
