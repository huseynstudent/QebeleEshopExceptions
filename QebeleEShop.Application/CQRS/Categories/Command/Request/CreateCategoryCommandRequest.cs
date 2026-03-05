using MediatR;
using QebeleEShop.Application.CQRS.Categories.Command.Response;
using QebeleEShop.Common.GlobalResponse;

namespace QebeleEShop.Application.CQRS.Categories.Command.Request;

public class CreateCategoryCommandRequest:IRequest<ResponseModel<CreateCategoryCommandResponse>>
{
    public string Name { get; set; }
}
