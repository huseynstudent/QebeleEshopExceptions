using MediatR;
using QebeleEShop.Application.CQRS.Categories.Query.Response;
using QebeleEShop.Common.GlobalResponse;

namespace QebeleEShop.Application.CQRS.Categories.Query.Request;

public class GetAllCategoryQueryRequest:IRequest<Pagination<GetAllCategoryQueryResponse>>
{
    public int Page { get; set; }
    public int Size { get; set; }
}
