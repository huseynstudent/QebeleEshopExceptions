using MediatR;
using QebeleEShop.Application.CQRS.Products.Query.Response;

namespace QebeleEShop.Application.CQRS.Products.Query.Request;

public class GetProductByIdQueryRequest: IRequest<GetProductByIdQueryResponse>
{
    public int Id { get; set; }
}
