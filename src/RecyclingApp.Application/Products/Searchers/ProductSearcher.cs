using Microsoft.EntityFrameworkCore;
using RecyclingApp.Application.Abstractions;
using RecyclingApp.Application.Pagination;
using RecyclingApp.Application.Products.Queries;
using RecyclingApp.Application.Products.Utilities;
using RecyclingApp.Application.Utilities;
using RecyclingApp.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Application.Products.Searchers;

internal class ProductSearcher : IProductSearcher
{
    private readonly IQueryable<Product> _query;

    public ProductSearcher(IApplicationDbContext context)
        => _query = context.Set<Product>().AsNoTracking();

    public async Task<PagedResponse<Product>> GetList(GetProducts query, CancellationToken cancellationToken)
        => await _query
            .Where(p => query.Name.IsNullOrWhiteSpace() || p.Name == query.Name)
            .Where(p => !query.Type.HasValue || p.Type.Equals(query.Type))
            .ApplyPriceFilter(minPrice: query.MinPrice, maxPrice: query.MaxPrice)
            .ApplySorting(sortingParams: query.Sorting)
            .TakePage(pageNumber: query.Page, pageSize: query.PageSize, cancellationToken: cancellationToken);

    public async Task<IReadOnlyCollection<Product>> GetByIds(IReadOnlyCollection<Guid> productIds, CancellationToken cancellationToken)
        => await _query
            .Where(p => productIds.Contains(p.Id))
            .ToListAsync(cancellationToken);
}
