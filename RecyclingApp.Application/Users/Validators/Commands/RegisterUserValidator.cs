using FluentValidation;
using RecyclingApp.Application.Users.Commands;
using System.Linq;

namespace RecyclingApp.Application.Users.Validators.Commands;

public class RegisterUserValidator : AbstractValidator<RegisterUser>
{
    public RegisterUserValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty();

        RuleFor(x => x.FirstName)
            .Length(2, 50)
            .Must(IsValidName).WithMessage("{PropertyName} contains invalid characters")
            .When(x => x.FirstName is not null);

        RuleFor(x => x.LastName)
            .NotEmpty();

        RuleFor(x => x.LastName)
            .Length(2, 50)
            .Must(IsValidName).WithMessage("{PropertyName} contains invalid characters")
            .When(x => x.LastName is not null);
    }

    protected static bool IsValidName(string name)
    {
        name = name.Replace(" ", "");
        name = name.Replace("-", "");
        return name.All(char.IsLetter);
    }
}
