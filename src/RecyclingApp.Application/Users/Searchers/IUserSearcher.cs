using RecyclingApp.Application.Pagination;
using RecyclingApp.Application.Users.Queries;
using RecyclingApp.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Application.Users.Searchers;

internal interface IUserSearcher
{
    Task<PagedResponse<User>> GetListAsync(GetUsers query, CancellationToken cancellationToken);
}
