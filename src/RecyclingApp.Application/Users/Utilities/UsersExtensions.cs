using RecyclingApp.Application.Exceptions;
using RecyclingApp.Application.Utilities;
using RecyclingApp.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace RecyclingApp.Application.Users.Utilities;

internal static class UsersExtensions
{
    internal static IOrderedQueryable<User> ApplySorting(this IQueryable<User> query, string[]? sortingParams)
        => query.Sort(propertyProvider: GetProperty, sortingParams: sortingParams);

    private static Expression<Func<User, object>> GetProperty(string propertyName)
        => propertyName switch
        {
            "firstname" => User => User.FirstName,
            "lastname" => User => User.LastName,
            var unknownProperty => throw new SortingPropertyDoesNotExistException(unknownProperty)
        };
}
