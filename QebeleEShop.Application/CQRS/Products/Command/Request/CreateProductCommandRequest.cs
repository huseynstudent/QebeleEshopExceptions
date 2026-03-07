using MediatR;
using QebeleEShop.Application.CQRS.Products.Command.Response;

namespace QebeleEShop.Application.CQRS.Products.Command.Request;

public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int CategoryId { get; set; }
}
