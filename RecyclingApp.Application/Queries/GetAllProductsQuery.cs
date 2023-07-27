using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RecyclingApp.Application.Filters;
using RecyclingApp.Application.Helpers;
using RecyclingApp.Application.Interfaces;
using RecyclingApp.Application.Models;
using RecyclingApp.Application.Wrappers;
using RecyclingApp.Domain.Model;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Application.Queries
{
    public class GetAllProductsQuery : IRequest<Response<IEnumerable<ProductDto>>>
    {
        public int Page { get; set; }
        public int Limit { get; set; }
        public string[] Type { get; set; }
        public string Name { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public string OrderBy { get; set; }

        public GetAllProductsQuery(int page, int limit, string[] type, string name, int minPrice,
            int maxPrice, string orderBy)
        {
            Page = page;
            Limit = limit;
            Type = type;
            Name = name;
            MinPrice = minPrice;
            MaxPrice = maxPrice;
            OrderBy = orderBy;
        }

        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, Response<IEnumerable<ProductDto>>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetAllProductsQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Response<IEnumerable<ProductDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var paramiters = _mapper.Map<PaginationFilter>(request);
                var productParamiters = _mapper.Map<ProductFilters>(request);

                var query = _context.Set<Product>().AsQueryable();
                var products = await query
                    .SearchProducts(productParamiters)
                    .FilterProducts(productParamiters)
                    .ApplaySorting(productParamiters.OrderBy)
                    .ApplayPaging(paramiters.Page, paramiters.Limit)
                    .ToListAsync(cancellationToken: cancellationToken);

                return new PagedResponse<IEnumerable<ProductDto>>(_mapper.Map<IEnumerable<ProductDto>>(products), products.Count);

            }
        }
    }
}
