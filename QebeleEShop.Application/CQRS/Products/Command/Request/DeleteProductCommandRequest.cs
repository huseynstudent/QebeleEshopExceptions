using MediatR;
using QebeleEShop.Application.CQRS.Products.Command.Response;
using QebeleEShop.Common.GlobalResponse;

namespace QebeleEShop.Application.CQRS.Products.Command.Request;

public class DeleteProductCommandRequest : IRequest<ResponseModel<DeleteProductCommandResponse>>
{
    public int Id { get; set; }
}
