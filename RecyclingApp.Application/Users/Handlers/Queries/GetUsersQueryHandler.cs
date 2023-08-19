using MediatR;
using RecyclingApp.Application.Abstractions;
using RecyclingApp.Application.Pagination;
using RecyclingApp.Application.Users.Models;
using RecyclingApp.Application.Users.Queries;
using RecyclingApp.Application.Users.Searchers;
using RecyclingApp.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Application.Users.Handlers.Queries;

internal class GetUsersQueryHandler : IRequestHandler<GetUsers, PagedResponse<UserResponse>>
{
    private readonly IUserSearcher _searcher;
    private readonly IResponseBuilder<User, UserResponse> _responseBuilder;

    public GetUsersQueryHandler(IUserSearcher searcher, IResponseBuilder<User, UserResponse> responseBuilder)
    {
        _searcher = searcher;
        _responseBuilder = responseBuilder;
    }

    public async Task<PagedResponse<UserResponse>> Handle(GetUsers request, CancellationToken cancellationToken)
    {
        var result = await _searcher.GetList(query: request, cancellationToken: cancellationToken);

        return new PagedResponse<UserResponse>(
            results: result.Results.Select(u => _responseBuilder.Build(input: u)).ToList(),
            pageInfo: result.PageInfo);
    }
}
