using AutoMapper;
using Moq;
using RecyclingApp.Application.Products.Commands;
using RecyclingApp.Application.Products.Handlers.Commands;
using RecyclingApp.Domain.Entities.Products;
using RecyclingApp.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace RecyclingApp.Tests
{
    public class CreateProductCommandHandlerTest
    {
        private readonly Mock<IRepository<Product>> _mockRepository;
        private readonly IMapper _mapper;
        //private readonly CreateProductCommandHandler _commandHandler;//TODO refactor

        /*public CreateProductCommandHandlerTest()
        {
            _mockRepository = new Mock<IRepository<Product>>();

            var configurationProvider = new MapperConfiguration(c => c.AddProfile<ApplicationProfile>());
            _mapper = configurationProvider.CreateMapper();

            _commandHandler = new CreateProductCommandHandler(_mockRepository.Object, _mapper);
        }

        [Fact]
        public async Task CreateProductTest()
        {
            var result = await _commandHandler.Handle(new CreateProduct("D",
                "productName", 77), CancellationToken.None);

            result.Data.Price.Equals(77);
        }*/
    }
}
