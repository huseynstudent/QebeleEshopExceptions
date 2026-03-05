
using FluentValidation;
using QebeleEShop.Application.CQRS.Categories.Command.Request;

namespace QebeleEShop.Application.Validations.CategoryValidations;

public class DeleteCategoryCommandRequestValidation:AbstractValidator<DeleteCategoryCommandRequest>
{
    public DeleteCategoryCommandRequestValidation()
    {
        RuleFor(request => request.Id).NotNull().WithMessage("The ID is required.")
        .GreaterThan(0).WithMessage("The ID must be greater than 0.");
    }
}
