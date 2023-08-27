using RecyclingApp.Application.Pagination;
using RecyclingApp.Application.Products.Queries;
using RecyclingApp.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Application.Products.Searchers;

internal interface IProductSearcher
{
    Task<PagedResponse<Product>> GetList(GetProducts query, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<Product>> GetByIds(IReadOnlyCollection<Guid> productIds, CancellationToken cancellationToken);
}
