using AutoMapper;
using Moq;
using RecyclingApp.Application.Orders.Commands;
using RecyclingApp.Application.Orders.Handlers.Commands;
using RecyclingApp.Domain.Entities.Orders;
using RecyclingApp.Domain.Repositories;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static RecyclingApp.Application.Orders.Commands.CreateOrder;

namespace RecyclingApp.Tests
{
    public class CreateOrderCommandHandlerTest
    {
        private readonly Mock<IRepository<Order>> _mockRepository;
        //private readonly CreateOrderCommandHandler _commandHandler; //TODO refactor
        private readonly IMapper _mapper;

        /*public CreateOrderCommandHandlerTest()
        {
            _mockRepository = new Mock<IRepository<Order>>();

            var configurationProvider = new MapperConfiguration(c => c.AddProfile<ApplicationProfile>());
            _mapper = configurationProvider.CreateMapper();

            _commandHandler = new CreateOrderCommandHandler(_mockRepository.Object, _mapper);

        }

        [Fact]
        public async Task CreateOrderTest()
        {
            var result = await _commandHandler.Handle(new CreateOrder(Guid.NewGuid(), 5), CancellationToken.None);

            result.Data.Status.Any();
            result.Data.Status.Equals("open");
        }*/

    }
}
