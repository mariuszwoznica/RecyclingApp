using MediatR;

namespace RecyclingApp.Application.Users.Commands;

public record RegisterUser(
     string FirstName,
     string LastName) : IRequest;
