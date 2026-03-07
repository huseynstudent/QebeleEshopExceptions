using FluentValidation;
using QebeleEShop.Application.CQRS.Products.Command.Request;

namespace QebeleEShop.Application.Validations.ProductValidations;

public class UpdateProductCommandRequestValidation: AbstractValidator<UpdateProductCommandRequest>
{
    public UpdateProductCommandRequestValidation()
    {
        RuleFor(request => request.Id).NotNull().WithMessage("The ID is required.")
            .GreaterThan(0).WithMessage("The ID must be greater than 0.");
        RuleFor(request => request.Name).NotEmpty().WithMessage("The product name is required.")
            .MaximumLength(100).WithMessage("The product name must not exceed 100 characters.");
        RuleFor(request => request.Price).GreaterThan(0).WithMessage("The product price must be greater than 0.");
        RuleFor(request => request.CategoryId).GreaterThan(0).WithMessage("The category ID must be greater than 0.");
    }
}
