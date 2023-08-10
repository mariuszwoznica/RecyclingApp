﻿using RecyclingApp.Application.Models;
using RecyclingApp.Application.Users.Queries;
using RecyclingApp.Domain.Model;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Application.Users.Searchers;

internal interface IUserSearcher
{
    Task<PageResponse<User>> GetList(GetUsers query, CancellationToken cancellationToken);
}
