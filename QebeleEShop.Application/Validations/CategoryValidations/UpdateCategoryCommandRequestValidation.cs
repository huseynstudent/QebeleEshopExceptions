using FluentValidation;
using QebeleEShop.Application.CQRS.Categories.Command.Request;

namespace QebeleEShop.Application.Validations.CategoryValidations;

public class UpdateCategoryCommandRequestValidation : AbstractValidator<UpdateCategoryCommandRequest>
{
    public UpdateCategoryCommandRequestValidation()
    {
        RuleFor(request=>request.Name).NotEmpty().WithMessage("Kategori adı boş olamaz")
            .MinimumLength(3).WithMessage("Kategori adı en az 3 karakter olmalıdır")
            .MaximumLength(50).WithMessage("Kategori adı en fazla 50 karakter olmalıdır");
        RuleFor(request => request.Id).NotNull().WithMessage("The ID is required.")
        .GreaterThan(0).WithMessage("The ID must be greater than 0.");
    }
}
