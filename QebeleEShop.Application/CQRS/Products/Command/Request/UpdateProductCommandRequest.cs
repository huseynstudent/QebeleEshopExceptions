using MediatR;
using QebeleEShop.Application.CQRS.Products.Command.Response;
using QebeleEShop.Common.GlobalResponse;

namespace QebeleEShop.Application.CQRS.Products.Command.Request;

public class UpdateProductCommandRequest : IRequest<ResponseModel<UpdateProductCommandResponse>>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int CategoryId { get; set; }
}
