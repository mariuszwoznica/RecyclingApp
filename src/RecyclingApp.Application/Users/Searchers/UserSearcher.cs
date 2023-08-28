using Microsoft.EntityFrameworkCore;
using RecyclingApp.Application.Abstractions;
using RecyclingApp.Application.Pagination;
using RecyclingApp.Application.Users.Queries;
using RecyclingApp.Application.Users.Utilities;
using RecyclingApp.Application.Utilities;
using RecyclingApp.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Application.Users.Searchers;

internal class UserSearcher : IUserSearcher
{
    private readonly IQueryable<User> _query;

    public UserSearcher(IApplicationDbContext context)
        => _query = context.Set<User>().AsNoTracking();

    public async Task<PagedResponse<User>> GetListAsync(GetUsers query, CancellationToken cancellationToken)
        => await _query
            .Where(u => query.FirstName.IsNullOrWhiteSpace() || u.FirstName.ToLower() == query.FirstName!.ToLower())
            .Where(u => query.LastName.IsNullOrWhiteSpace() || u.LastName.ToLower() == query.LastName!.ToLower())
            .ApplySorting(sortingParams: query.Sorting)
            .TakePageAsync(pageNumber: query.Page, pageSize: query.PageSize, cancellationToken: cancellationToken);
}