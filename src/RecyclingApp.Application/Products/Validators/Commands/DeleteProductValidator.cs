using FluentValidation;
using RecyclingApp.Application.Products.Commands;

namespace RecyclingApp.Application.Products.Validators.Commands;

public class DeleteProductValidator : AbstractValidator<DeleteProduct>
{
    public DeleteProductValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty();
    }
}
