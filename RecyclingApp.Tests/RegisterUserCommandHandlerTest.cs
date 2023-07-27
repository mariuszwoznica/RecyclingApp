using AutoMapper;
using Moq;
using RecyclingApp.Application.Commands;
using RecyclingApp.Application.Mapper;
using RecyclingApp.Domain.Interfaces;
using RecyclingApp.Domain.Model;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static RecyclingApp.Application.Commands.RegisterUserCommand;

namespace RecyclingApp.Tests
{
    public class RegisterUserCommandHandlerTest
    {
        private readonly Mock<IRepository<User>> _mockRepository;
        private readonly RegisterUserCommandHandler _commandHandler;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandlerTest()
        {
            _mockRepository = new Mock<IRepository<User>>();

            var configurationProvider = new MapperConfiguration(c => c.AddProfile<ApplicationProfile>());
            _mapper = configurationProvider.CreateMapper();

            _commandHandler = new RegisterUserCommandHandler(_mockRepository.Object, _mapper);
        }

        [Fact]
        public async Task RegisterUserTest()
        {
            var result = await _commandHandler.Handle(new RegisterUserCommand("Anna", "Kowalska"), CancellationToken.None);

            result.Data.FirstName.Equals(result.Data.FirstName == "Anna");
        }
    }
}
