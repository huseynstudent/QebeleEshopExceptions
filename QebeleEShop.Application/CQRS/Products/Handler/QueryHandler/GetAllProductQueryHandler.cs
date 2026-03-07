using MediatR;
using QebeleEShop.Application.CQRS.Products.Query.Request;
using QebeleEShop.Application.CQRS.Products.Query.Response;
using QebeleEShop.Common.GlobalResponse;
using QebeleEShop.Repository.Common;


namespace QebeleEShop.Application.CQRS.Products.Handler.QueryHandler;

public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, Pagination<GetAllProductQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllProductQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<Pagination<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
    {
        var products = _unitOfWork.ProductRepository.GetAll().Select(p => new GetAllProductQueryResponse
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            CategoryId = p.CategoryId
        }).ToList();

        var totalCount = products.Count;
        var paginated = products
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToList();

        var pagination = new Pagination<GetAllProductQueryResponse>(paginated, totalCount, request.Page, request.PageSize);
        return Task.FromResult(pagination);
    }
}