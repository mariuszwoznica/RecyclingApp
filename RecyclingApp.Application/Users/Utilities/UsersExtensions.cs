using RecyclingApp.Application.Exceptions;
using RecyclingApp.Application.Utilities;
using RecyclingApp.Domain.Model;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace RecyclingApp.Application.Users.Utilities;

internal static class UsersExtensions
{
    internal static IOrderedQueryable<User> ApplySorting(this IQueryable<User> query, string[]? sortingParams)
    {
        if (!sortingParams.IsNullOrEmpty())
        {
            var orderingCount = 0;
            foreach (var param in sortingParams!)
            {
                var propertyName = param.Split('\u002C').Select(p => p.Trim().ToLower()).First();
                if (param.EndsWith("desc"))
                    query = orderingCount == 0
                        ? query.OrderByDescending(GetSortProperty(propertyName))
                        : query.ThenByDescending(GetSortProperty(propertyName));
                else
                    query = orderingCount == 0
                        ? query.OrderBy(GetSortProperty(propertyName))
                        : query.ThenBy(GetSortProperty(propertyName));
                orderingCount++;
            }
            return query.ThenBy(o => o.Id);
        }
        else
            return query.OrderBy(o => o.Id);
    }

    private static Expression<Func<User, object>> GetSortProperty(string property)
        => property switch
        {
            "firstname" => User => User.FirstName,
            "lastname" => User => User.LastName,
            var unknownProperty => throw new SortingPropertyDoesNotExistException(unknownProperty)
        };
}
