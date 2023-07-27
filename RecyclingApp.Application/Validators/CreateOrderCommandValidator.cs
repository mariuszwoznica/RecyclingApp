using FluentValidation;
using RecyclingApp.Application.Commands;

namespace RecyclingApp.Application.Validators
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
