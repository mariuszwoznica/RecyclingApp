﻿using Microsoft.EntityFrameworkCore;
using RecyclingApp.Application.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Application.Utilities;

public static class PagingExtensions
{
    public static async Task<PageResponse<T>> TakePage<T>(this IQueryable<T> query, int pageNumber, int pageSize,
        CancellationToken cancellationToken)
    {
        var results = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new PageResponse<T>(
            results: results,
            pageInfo: new PagingInfo(
                pageNumber: pageNumber,
                pageSize: pageSize,
                totalCount: await query.CountAsync(cancellationToken)));
    }
}