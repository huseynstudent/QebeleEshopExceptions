using MediatR;
using QebeleEShop.Application.CQRS.Categories.Command.Request;
using QebeleEShop.Application.CQRS.Categories.Command.Response;
using QebeleEShop.Common.GlobalResponse;
using QebeleEShop.Domain.Entities;
using QebeleEShop.Repository.Common;

namespace QebeleEShop.Application.CQRS.Categories.Handler.CommandHandlers;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, ResponseModel<CreateCategoryCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<CreateCategoryCommandResponse>> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var category = new Category
        {
            Name = request.Name,
            CreatedDate = DateTime.UtcNow
        };
        await _unitOfWork.CategoryRepository.AddAsync(category);
        await _unitOfWork.Save();
        var response = new CreateCategoryCommandResponse
        {
            Id = category.Id,
            Name = category.Name
        };
        return new ResponseModel<CreateCategoryCommandResponse>(response);

    }
}
