﻿using MediatR;
using RecyclingApp.Application.Pagination;
using RecyclingApp.Application.Users.Models;

namespace RecyclingApp.Application.Users.Queries;

public record GetUsers(
    int Page,
    int PageSize,
    string? FirstName,
    string? LastName,
    string[]? Sorting) : IRequest<PagedResponse<UserResponse>>;
