using FluentValidation;
using RecyclingApp.Application.Orders.Commands;

namespace RecyclingApp.Application.Orders.Validators.Commands;

public class CreateOrderValidator : AbstractValidator<CreateOrder>
{
    public CreateOrderValidator()
    {
        RuleFor(x => x.ProductIds)
            .NotEmpty();

        RuleFor(x => x.Quantity)
            .NotEmpty();
    }
}
