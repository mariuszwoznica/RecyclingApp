using Microsoft.Extensions.DependencyInjection;
using RecyclingApp.Application.Users.Builders;
using RecyclingApp.Application.Users.Models;
using RecyclingApp.Application.Users.Searchers;
using RecyclingApp.Domain.Entities;

namespace RecyclingApp.Application.Users;

internal static class UsersServiceCollectionExtensions
{
    internal static IServiceCollection AddUsers(this IServiceCollection services)
        => services
            .AddScoped<IUserSearcher, UserSearcher>()
            .RegisterResponseBuilder<User, UserResponse, UserResponseBuilder>();
}
