﻿using System.Collections.Generic;

namespace RecyclingApp.Application.Pagination;

public class PagedResponse<T>
{
    public IReadOnlyCollection<T> Results { get; }
    public PagingInfo PageInfo { get; }

    public PagedResponse(IReadOnlyCollection<T> results, PagingInfo pageInfo)
    {
        Results = results;
        PageInfo = pageInfo;
    }
}