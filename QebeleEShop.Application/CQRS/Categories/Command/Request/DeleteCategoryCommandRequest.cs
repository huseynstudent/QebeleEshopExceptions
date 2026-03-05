using MediatR;
using QebeleEShop.Application.CQRS.Categories.Command.Response;
using QebeleEShop.Common.GlobalResponse;

namespace QebeleEShop.Application.CQRS.Categories.Command.Request;

public class DeleteCategoryCommandRequest : IRequest<ResponseModel<DeleteCategoryCommandResponse>>
{
    public int Id { get; set; }
}
