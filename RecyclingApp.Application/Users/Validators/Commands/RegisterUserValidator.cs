using FluentValidation;
using RecyclingApp.Application.Users.Commands;
using System.Linq;

namespace RecyclingApp.Application.Users.Validators.Commands;

public class RegisterUserValidator : AbstractValidator<RegisterUser>
{
    public RegisterUserValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .Length(2, 50)
            .Must(ValidName).WithMessage("{PropertyName} zawiera niepoprawne znaki");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .Length(2, 50)
            .Must(ValidName).WithMessage("{PropertyName} zawiera niepoprawne znaki");
    }

    protected static bool ValidName(string name)
    {
        name = name.Replace(" ", "");
        name = name.Replace("-", "");
        return name.All(char.IsLetter);
    }
}
