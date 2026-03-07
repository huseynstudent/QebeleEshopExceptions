namespace QebeleEShop.Application.Validations.ProductValidations;
using FluentValidation;
using QebeleEShop.Application.CQRS.Products.Query.Request;

public class GetProductByIdQueryRequestValidation: AbstractValidator<GetProductByIdQueryRequest>
{
    public GetProductByIdQueryRequestValidation()
    {
        RuleFor(request => request.Id).NotNull().WithMessage("The ID is required.")
            .GreaterThan(0).WithMessage("The ID must be greater than 0.");
    }
}
