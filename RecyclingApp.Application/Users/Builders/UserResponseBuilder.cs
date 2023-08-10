using RecyclingApp.Application.Interfaces;
using RecyclingApp.Application.Users.Models;
using RecyclingApp.Domain.Model;

namespace RecyclingApp.Application.Users.Builders;

internal class UserResponseBuilder : IResponseBuilder<User, UserResponse>
{
    public UserResponse Build(User input)
        => new(
            FirstName: input.FirstName,
            LastName: input.LastName
            );
}
