using FluentAssertions;
using RecyclingApp.Application.Users.Commands;
using RecyclingApp.Application.Users.Validators.Commands;
using RecyclingApp.Tests.Common.Utilities;
using System.Threading.Tasks;
using Xunit;

namespace RecyclingApp.Tests.User.Validators.Commands;

public class RegisterUserValidatorTests
{
    private readonly RegisterUserValidator _validator;

    public RegisterUserValidatorTests()
        => _validator = new RegisterUserValidator();

    [Theory]
    [InlineData(null, false)]
    [InlineData(" ", false)]
    [InlineData("", false)]
    public async Task FirstName_IsEmpty_Params(string name, bool isValid)
    {
        //Arrange
        var command = new RegisterUser(name, "lastName");

        //Act
        var result = await _validator.ValidateAsync(command);

        //Assert
        result.IsValid.Should().Be(isValid);
        if (!isValid)
            result.Errors.Should().Contain(x => x.PropertyName == nameof(RegisterUser.FirstName));
    }

    [Theory]
    [InlineData(55, false)]
    [InlineData(50, true)]
    [InlineData(35, true)]
    public async Task FirstName_MaximumLength_Params(int length, bool isValid)
    {
        //Arrange
        var command = new RegisterUser(RandomGenerator.GetText(length), "lastName");

        //Act
        var result = await _validator.ValidateAsync(command);

        //Assert
        result.IsValid.Should().Be(isValid);
        if (!isValid)
            result.Errors.Should().HaveCount(1)
                .And.Contain(x => x.PropertyName == nameof(RegisterUser.FirstName));
    }

    [Theory]
    [InlineData(1, false)]
    [InlineData(2, true)]
    [InlineData(10, true)]
    public async Task FirstName_MinimumLength_Params(int length, bool isValid)
    {
        //Arrange
        var command = new RegisterUser(RandomGenerator.GetText(length), "lastName");

        //Act
        var result = await _validator.ValidateAsync(command);

        //Assert
        result.IsValid.Should().Be(isValid);
        if (!isValid)
            result.Errors.Should().HaveCount(1)
                .And.Contain(x => x.PropertyName == nameof(RegisterUser.FirstName));
    }

    [Theory]
    [InlineData("xcv-12ab", false)]
    [InlineData("xc!gl09", false)]
    [InlineData("name", true)]
    public async Task FirstName_IsValidName_Params(string name, bool isValid)
    {
        //Arrange
        var command = new RegisterUser(name, "lastName");

        //Act
        var result = await _validator.ValidateAsync(command);

        //Assert
        result.IsValid.Should().Be(isValid);
        if (!isValid)
            result.Errors.Should().HaveCount(1)
                .And.Contain(x => x.PropertyName == nameof(RegisterUser.FirstName));
    }

    [Theory]
    [InlineData(null, false)]
    [InlineData(" ", false)]
    [InlineData("", false)]
    public async Task LastName_IsEmpty_ValidationFailed(string name, bool isValid)
    {
        //Arrange
        var command = new RegisterUser("firstName", name);

        //Act
        var result = await _validator.ValidateAsync(command);

        //Assert
        result.IsValid.Should().Be(isValid);
        if (!isValid)
            result.Errors.Should().Contain(x => x.PropertyName == nameof(RegisterUser.LastName));
    }

    [Theory]
    [InlineData(55, false)]
    [InlineData(50, true)]
    [InlineData(35, true)]
    public async Task LastName_MaximumLength_Params(int length, bool isValid)
    {
        //Arrange
        var command = new RegisterUser("firstName", RandomGenerator.GetText(length));

        //Act
        var result = await _validator.ValidateAsync(command);

        //Assert
        result.IsValid.Should().Be(isValid);
        if (!isValid)
            result.Errors.Should().HaveCount(1)
                .And.Contain(x => x.PropertyName == nameof(RegisterUser.LastName));
    }

    [Theory]
    [InlineData(1, false)]
    [InlineData(2, true)]
    [InlineData(10, true)]
    public async Task LastName_MinimumLength_Params(int length, bool isValid)
    {
        //Arrange
        var command = new RegisterUser("firstName", RandomGenerator.GetText(length));

        //Act
        var result = await _validator.ValidateAsync(command);

        //Assert
        result.IsValid.Should().Be(isValid);
        if (!isValid)
            result.Errors.Should().HaveCount(1)
                .And.Contain(x => x.PropertyName == nameof(RegisterUser.LastName));
    }

    [Theory]
    [InlineData("xcv-12ab", false)]
    [InlineData("xc!gl09", false)]
    [InlineData("name", true)]
    public async Task LastName_IsValidName_Params(string name, bool isValid)
    {
        //Arrange
        var command = new RegisterUser("firstName", name);

        //Act
        var result = await _validator.ValidateAsync(command);

        //Assert
        result.IsValid.Should().Be(isValid);
        if (!isValid)
            result.Errors.Should().HaveCount(1)
                .And.Contain(x => x.PropertyName == nameof(RegisterUser.LastName));
    }
}
