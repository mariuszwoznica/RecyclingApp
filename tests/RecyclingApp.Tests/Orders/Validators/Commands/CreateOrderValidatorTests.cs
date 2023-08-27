using FluentAssertions;
using RecyclingApp.Application.Orders.Commands;
using RecyclingApp.Application.Orders.Validators.Commands;
using System;
using System.Threading.Tasks;
using Xunit;

namespace RecyclingApp.Tests.Orders.Validators.Commands;

public class CreateOrderValidatorTests
{
    private readonly CreateOrderValidator _validator;

    public CreateOrderValidatorTests()
        => _validator = new CreateOrderValidator();

    [Fact]
    public async Task ProductIds_AreEmpty_ValidationFailed()
    {
        // Arrange
        var command = new CreateOrder(null, new[] { 5 });

        // Act
        var result = await _validator.ValidateAsync(command);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().HaveCount(1)
            .And.Contain(x => x.PropertyName == nameof(CreateOrder.ProductIds));
    }

    [Fact]
    public async Task Quantities_AreEmpty_ValidationFailed()
    {
        // Arrange
        var command = new CreateOrder(new[] { Guid.NewGuid() }, null);

        // Act
        var result = await _validator.ValidateAsync(command);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().HaveCount(1)
            .And.Contain(x => x.PropertyName == nameof(CreateOrder.Quantities));
    }
}
