using AutoMapper;
using MediatR;
using RecyclingApp.Application.Models;
using RecyclingApp.Application.Wrappers;
using RecyclingApp.Domain.Interfaces;
using RecyclingApp.Domain.Model;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.Application.Commands
{
    public class RegisterUserCommand : IRequest<Response<UserDto>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public RegisterUserCommand(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Response<UserDto>>
        {
            private readonly IRepository<User> _userRepository;
            private readonly IMapper _mapper;

            public RegisterUserCommandHandler(IRepository<User> userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<Response<UserDto>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                var user = User.Create(request.FirstName, request.LastName);
                _userRepository.Add(user);
                await _userRepository.SaveChangesAsync();

                return new Response<UserDto>(_mapper.Map<UserDto>(user));
            }

        }
    }
}
