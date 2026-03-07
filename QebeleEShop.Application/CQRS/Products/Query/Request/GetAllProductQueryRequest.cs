using MediatR;
using QebeleEShop.Application.CQRS.Products.Query.Response;
using QebeleEShop.Common.GlobalResponse;

namespace QebeleEShop.Application.CQRS.Products.Query.Request;

public class GetAllProductQueryRequest : IRequest<Pagination<GetAllProductQueryResponse>>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
}
