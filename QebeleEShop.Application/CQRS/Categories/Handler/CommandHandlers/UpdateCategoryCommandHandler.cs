
using MediatR;
using QebeleEShop.Application.CQRS.Categories.Command.Request;
using QebeleEShop.Application.CQRS.Categories.Command.Response;
using QebeleEShop.Common.GlobalResponse;
using QebeleEShop.Repository.Common;

namespace QebeleEShop.Application.CQRS.Categories.Handler.CommandHandlers;

public class UpdateCategoryCommandHandler :IRequestHandler<UpdateCategoryCommandRequest, ResponseModel<UpdateCategoryCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ResponseModel<UpdateCategoryCommandResponse>> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id);
        if (category == null)
        {
            return new ResponseModel<UpdateCategoryCommandResponse>(null);
        }
        category.Name = request.Name;
        _unitOfWork.CategoryRepository.UpdateAsync(category);
        await _unitOfWork.Save();
        var response = new UpdateCategoryCommandResponse
        {
            Id = category.Id,
            Name = category.Name
        };
        return new ResponseModel<UpdateCategoryCommandResponse>(response);
    }

}
