using MediatR;
using QebeleEShop.Application.CQRS.Products.Command.Request;
using QebeleEShop.Application.CQRS.Products.Command.Response;
using QebeleEShop.Common.GlobalResponse;
using QebeleEShop.Repository.Common;

namespace QebeleEShop.Application.CQRS.Products.Handler.CommandHandler;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, ResponseModel<DeleteProductCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<DeleteProductCommandResponse>> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id);
        _unitOfWork.ProductRepository.Delete(request.Id);
        await _unitOfWork.Save();

        var response = new DeleteProductCommandResponse
        {
            Id = product.Id,
            Name = $"Deleted {product.Name}",
            Price = product.Price,
            CategoryId = product.CategoryId
        };

        return new ResponseModel<DeleteProductCommandResponse>(response);
    }
}