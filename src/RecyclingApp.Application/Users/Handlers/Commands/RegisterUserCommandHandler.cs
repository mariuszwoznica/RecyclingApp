using MediatR;
using RecyclingApp.Application.Users.Commands;
using RecyclingApp.Domain.Entities;
using RecyclingApp.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Application.Users.Handlers.Commands;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUser>
{
    private readonly IRepository<User> _userRepository;

    public RegisterUserCommandHandler(IRepository<User> userRepository)
        => _userRepository = userRepository;

    public async Task Handle(RegisterUser request, CancellationToken cancellationToken)
    {
        var user = User.Create(request.FirstName, request.LastName);
        _userRepository.Add(user);
        await _userRepository.SaveChangesAsync();
    }
}
