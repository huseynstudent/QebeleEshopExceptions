using FluentValidation;
using QebeleEShop.Application.CQRS.Categories.Command.Request;

namespace QebeleEShop.Application.Validations.CategoryValidations;

public class CreateCategoryCommandRequestValidation: AbstractValidator<CreateCategoryCommandRequest>
{
    public CreateCategoryCommandRequestValidation()
    {
        RuleFor(request=>request.Name)
            .NotEmpty().WithMessage("Kategori adı boş olamaz")
            .MinimumLength(3).WithMessage("Kategori adı en az 3 karakter olmalıdır")
            .MaximumLength(50).WithMessage("Kategori adı en fazla 50 karakter olmalıdır");
    }
}
