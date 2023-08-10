using FluentValidation;
using RecyclingApp.Application.Orders.Commands;

namespace RecyclingApp.Application.Validators
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrder>
    {
        public CreateOrderCommandValidator() //TODO: refactor, move
        {

        }
    }
}
