using FluentValidation;
using QebeleEShop.Application.CQRS.Products.Command.Request;

namespace QebeleEShop.Application.Validations.ProductValidations;

public class DeleteProductCommandRequestValidator: AbstractValidator<DeleteProductCommandRequest>
{
    public DeleteProductCommandRequestValidator()
    {
        RuleFor(request => request.Id).NotNull().WithMessage("The ID is required.")
            .GreaterThan(0).WithMessage("The ID must be greater than 0.");
    }
}
