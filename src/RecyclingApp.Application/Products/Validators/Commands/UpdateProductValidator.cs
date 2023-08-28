using FluentValidation;
using RecyclingApp.Application.Products.Commands;

namespace RecyclingApp.Application.Products.Validators.Commands;

public class UpdateProductValidator : AbstractValidator<UpdateProduct>
{
    public UpdateProductValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty();

        RuleFor(x => x.Type)
            .NotEmpty();

        RuleFor(x => x.Type)
            .IsInEnum()
            .WithMessage("Product type is not valid.");

        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.Price)
            .NotEmpty();
    }
}