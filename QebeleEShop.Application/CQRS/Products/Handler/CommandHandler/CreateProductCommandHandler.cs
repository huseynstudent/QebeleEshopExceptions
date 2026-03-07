using MediatR;
using QebeleEShop.Application.CQRS.Products.Command.Request;
using QebeleEShop.Application.CQRS.Products.Command.Response;
using QebeleEShop.Domain.Entities;
using QebeleEShop.Repository.Common;


namespace QebeleEShop.Application.CQRS.Products.Handler.CommandHandler;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            Price = request.Price,
            CategoryId = request.CategoryId,
            CreatedDate = DateTime.UtcNow
        };

        await _unitOfWork.ProductRepository.AddAsync(product);
        await _unitOfWork.Save();

        var response = new CreateProductCommandResponse
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            CategoryId = product.CategoryId
        };

        return response;
    }
}