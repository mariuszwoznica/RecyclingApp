using FluentAssertions;
using RecyclingApp.Application.Products.Commands;
using RecyclingApp.Application.Products.Validators.Commands;
using System;
using System.Threading.Tasks;
using Xunit;

namespace RecyclingApp.Tests.Products.Validators.Commands;

public class DeleteProductValidatorTests
{
    private readonly DeleteProductValidator _validator;

    public DeleteProductValidatorTests()
        => _validator = new DeleteProductValidator();

    [Fact]
    public async Task ProductId_IsEmpty_ValidationFaild()
    {
        // Arrange
        var command = new DeleteProduct(Guid.Empty);

        // Act
        var result = await _validator.ValidateAsync(command);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().HaveCount(1)
            .And.Contain(x => x.PropertyName == nameof(DeleteProduct.ProductId));
    }
}
