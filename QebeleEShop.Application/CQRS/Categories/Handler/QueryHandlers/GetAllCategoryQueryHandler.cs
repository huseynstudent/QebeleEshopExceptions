using MediatR;
using QebeleEShop.Application.CQRS.Categories.Query.Request;
using QebeleEShop.Application.CQRS.Categories.Query.Response;
using QebeleEShop.Common.GlobalResponse;
using QebeleEShop.Repository.Common;

namespace QebeleEShop.Application.CQRS.Categories.Handler.QueryHandlers;

public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, Pagination<GetAllCategoryQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCategoryQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<Pagination<GetAllCategoryQueryResponse>> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        var categories = _unitOfWork.CategoryRepository.GetAll().Select(c => new GetAllCategoryQueryResponse
        {
            Id = c.Id,
            Name = c.Name
        }).ToList();
        var totalCount = categories.Count;
        var paginatedCategories = categories.Skip((request.Page - 1) * request.Size).Take(request.Size).ToList();
        var pagination = new Pagination<GetAllCategoryQueryResponse>(paginatedCategories, totalCount, request.Page, request.Size);
        return Task.FromResult(pagination);
    }
}
