namespace QebeleEShop.Application.CQRS.Products.Command.Response;

public class CreateProductCommandResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int CategoryId { get; set; }
}
