using MediatR;
using QebeleEShop.Application.CQRS.Products.Query.Request;
using QebeleEShop.Application.CQRS.Products.Query.Response;
using QebeleEShop.Repository.Common;

namespace QebeleEShop.Application.CQRS.Products.Handler.QueryHandler;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryRequest, GetProductByIdQueryResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetProductByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id);
        if (product == null)
        {
            return null;
        }

        var response = new GetProductByIdQueryResponse
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            CategoryId = product.CategoryId
        };

        return response;
    }
}