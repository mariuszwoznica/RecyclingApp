using RecyclingApp.Application.Models;
using RecyclingApp.Application.Products.Queries;
using RecyclingApp.Domain.Model.Products;
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
