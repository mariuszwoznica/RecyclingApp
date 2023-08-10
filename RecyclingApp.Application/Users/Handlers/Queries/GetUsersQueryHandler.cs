using MediatR;
using RecyclingApp.Application.Interfaces;
using RecyclingApp.Application.Models;
using RecyclingApp.Application.Users.Models;
using RecyclingApp.Application.Users.Queries;
using RecyclingApp.Application.Users.Searchers;
using RecyclingApp.Domain.Model;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Application.Users.Handlers.Queries;

internal class GetUsersQueryHandler : IRequestHandler<GetUsers, PageResponse<UserResponse>>
{
    private readonly IUserSearcher _searcher;
    private readonly IResponseBuilder<User, UserResponse> _responseBuilder;

    public GetUsersQueryHandler(IUserSearcher searcher, IResponseBuilder<User, UserResponse> responseBuilder)
    {
        _searcher = searcher;
        _responseBuilder = responseBuilder;
    }

    public async Task<PageResponse<UserResponse>> Handle(GetUsers request, CancellationToken cancellationToken)
    {
        var result = await _searcher.GetList(query: request, cancellationToken: cancellationToken);

        return new PageResponse<UserResponse>(
            results: result.Results.Select(u => _responseBuilder.Build(input: u)).ToList(),
            pageInfo: result.PageInfo);
    }
}
