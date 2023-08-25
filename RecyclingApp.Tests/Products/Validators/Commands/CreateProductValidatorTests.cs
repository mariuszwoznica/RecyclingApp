using FluentAssertions;
using RecyclingApp.Application.Products.Commands;
using RecyclingApp.Application.Products.Models;
using RecyclingApp.Application.Products.Validators.Commands;
using System.Threading.Tasks;
using Xunit;

namespace RecyclingApp.Tests.Products.Validators.Commands;

public class CreateProductValidatorTests
{
    private readonly CreateProductValidator _validator;

    public CreateProductValidatorTests()
        => _validator = new CreateProductValidator();

    [Theory]
    [InlineData(10, false)]
    [InlineData(1, true)]
    [InlineData(2, true)]
    public async Task Type_IsInEnumValidation(int typeValue, bool isValid)
    {
        // Arrange
        var command = new CreateProduct((ProductType)typeValue, "name", 55);

        // Act
        var result = await _validator.ValidateAsync(command);

        // Assert
        result.IsValid.Should().Be(isValid);

        if (!isValid)
            result.Errors.Should().HaveCount(1)
                .And.Contain(x => x.PropertyName == nameof(CreateProduct.Type));
    }

    [Theory]
    [InlineData(null, false)]
    [InlineData(" ", false)]
    [InlineData("", false)]
    public async Task Name_IsEmpty_Params(string name, bool isValid)
    {
        //Arrange
        var command = new CreateProduct(ProductType.LightBulbsBox, name, 55);

        //Act
        var result = await _validator.ValidateAsync(command);

        //Assert
        result.IsValid.Should().Be(isValid);
        if (!isValid)
            result.Errors.Should().HaveCount(1)
            .And.Contain(x => x.PropertyName == nameof(CreateProduct.Name));
    }

    [Fact]
    public async Task Price_IsEmpty_ValidationFailed()
    {
        // Arrange
        var command = new CreateProduct(ProductType.LightBulbsBox, "name", default);

        // Act
        var result = await _validator.ValidateAsync(command);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().HaveCount(1)
            .And.Contain(x => x.PropertyName == nameof(CreateProduct.Price));
    }
}
