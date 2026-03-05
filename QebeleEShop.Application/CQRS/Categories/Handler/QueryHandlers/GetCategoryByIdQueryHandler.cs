using MediatR;
using QebeleEShop.Application.CQRS.Categories.Query.Request;
using QebeleEShop.Application.CQRS.Categories.Query.Response;
using QebeleEShop.Repository.Common;

namespace QebeleEShop.Application.CQRS.Categories.Handler.QueryHandlers;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQueryRequest, GetCategoryByIdQueryResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetCategoryByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<GetCategoryByIdQueryResponse> Handle(GetCategoryByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id);
        if (category == null)
        {
            return null;
        }
        var response = new GetCategoryByIdQueryResponse
        {
            Id = category.Id,
            Name = category.Name
        };
        return response;
    }
}
