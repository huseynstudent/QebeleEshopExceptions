
using MediatR;
using QebeleEShop.Application.CQRS.Categories.Command.Request;
using QebeleEShop.Application.CQRS.Categories.Command.Response;
using QebeleEShop.Common.GlobalResponse;
using QebeleEShop.Repository.Common;

namespace QebeleEShop.Application.CQRS.Categories.Handler.CommandHandlers;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, ResponseModel<DeleteCategoryCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<DeleteCategoryCommandResponse>> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id);
        _unitOfWork.CategoryRepository.Delete(request.Id);
        await _unitOfWork.Save();
        var response = new DeleteCategoryCommandResponse
        {
            Id = category.Id,
            Name = $"Deleted {category.Name}"
        };
        return new ResponseModel<DeleteCategoryCommandResponse>(response);
    }
}