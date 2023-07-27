using AutoMapper;
using Moq;
using RecyclingApp.Application.Commands;
using RecyclingApp.Application.Mapper;
using RecyclingApp.Domain.Interfaces;
using RecyclingApp.Domain.Model;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static RecyclingApp.Application.Commands.CreateProductCommand;

namespace RecyclingApp.Tests
{
    public class CreateProductCommandHandlerTest
    {
        private readonly Mock<IRepository<Product>> _mockRepository;
        private readonly IMapper _mapper;
        private readonly CreateProductCommandHandler _commandHandler;

        public CreateProductCommandHandlerTest()
        {
            _mockRepository = new Mock<IRepository<Product>>();

            var configurationProvider = new MapperConfiguration(c => c.AddProfile<ApplicationProfile>());
            _mapper = configurationProvider.CreateMapper();

            _commandHandler = new CreateProductCommandHandler(_mockRepository.Object, _mapper);
        }

        [Fact]
        public async Task CreateProductTest()
        {
            var result = await _commandHandler.Handle(new CreateProductCommand("D",
                "productName", 77), CancellationToken.None);

            result.Data.Price.Equals(77);
        }
    }
}
