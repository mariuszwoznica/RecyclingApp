using FluentValidation;
using RecyclingApp.Application.Commands;

namespace RecyclingApp.Application.Validators
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Type).NotEmpty();

            RuleFor(x => x.Name).NotEmpty();

            RuleFor(x => x.Price).NotEmpty();
        }
    }
}
