using FluentValidation;
using RecyclingApp.Application.Products.Commands;

namespace RecyclingApp.Application.Validators
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProduct>
    {
        public CreateProductCommandValidator() //TODO: refactor, move
        {
            //RuleFor(x => x.Type).NotEmpty();

            RuleFor(x => x.Name).NotEmpty();

            RuleFor(x => x.Price).NotEmpty();
        }
    }
}
