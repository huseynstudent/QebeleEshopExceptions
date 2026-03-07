using FluentValidation;
using QebeleEShop.Application.CQRS.Categories.Query.Request;

namespace QebeleEShop.Application.Validations.CategoryValidations;

public class GetCategoryByIdQueryRequestValidation: AbstractValidator<GetCategoryByIdQueryRequest>
{
    public GetCategoryByIdQueryRequestValidation()
    {
        RuleFor(request => request.Id).NotNull().WithMessage("The ID is required.")
            .GreaterThan(0).WithMessage("The ID must be greater than 0.");
    }
}
