using AutoMapper;
using Moq;
using RecyclingApp.Application.Commands;
using RecyclingApp.Application.Mapper;
using RecyclingApp.Domain.Interfaces;
using RecyclingApp.Domain.Model;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static RecyclingApp.Application.Commands.CreateOrderCommand;

namespace RecyclingApp.Tests
{
    public class CreateOrderCommandHandlerTest
    {
        private readonly Mock<IRepository<Order>> _mockRepository;
        private readonly CreateOrderCommandHandler _commandHandler;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandlerTest()
        {
            _mockRepository = new Mock<IRepository<Order>>();

            var configurationProvider = new MapperConfiguration(c => c.AddProfile<ApplicationProfile>());
            _mapper = configurationProvider.CreateMapper();

            _commandHandler = new CreateOrderCommandHandler(_mockRepository.Object, _mapper);

        }

        [Fact]
        public async Task CreateOrderTest()
        {
            var result = await _commandHandler.Handle(new CreateOrderCommand("orderName"), CancellationToken.None);

            result.Data.Status.Any();
            result.Data.Status.Equals("open");
        }

    }
}
