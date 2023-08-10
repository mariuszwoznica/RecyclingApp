using System.Collections.Generic;

namespace RecyclingApp.Application.Models;

public class PageResponse<T>
{
    public IReadOnlyCollection<T> Results { get; }
    public PagingInfo PageInfo { get; }

    public PageResponse(IReadOnlyCollection<T> results, PagingInfo pageInfo)
    {
        Results = results;
        PageInfo = pageInfo;
    }
}