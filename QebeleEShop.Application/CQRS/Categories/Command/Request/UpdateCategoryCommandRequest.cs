

using MediatR;
using QebeleEShop.Application.CQRS.Categories.Command.Response;
using QebeleEShop.Common.GlobalResponse;

namespace QebeleEShop.Application.CQRS.Categories.Command.Request;

public class UpdateCategoryCommandRequest : IRequest<ResponseModel<UpdateCategoryCommandResponse>>
{
    public int Id { get; set; }
    public string Name { get; set; }
}
