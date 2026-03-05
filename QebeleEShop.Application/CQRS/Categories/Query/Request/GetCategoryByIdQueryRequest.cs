using MediatR;
using QebeleEShop.Application.CQRS.Categories.Query.Response;

namespace QebeleEShop.Application.CQRS.Categories.Query.Request;

public class GetCategoryByIdQueryRequest: IRequest<GetCategoryByIdQueryResponse>
{
    public int Id { get; set; }
}
