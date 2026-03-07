using MediatR;
using QebeleEShop.Application.CQRS.Products.Command.Request;
using QebeleEShop.Application.CQRS.Products.Command.Response;
using QebeleEShop.Common.GlobalResponse;
using QebeleEShop.Repository.Common;

namespace QebeleEShop.Application.CQRS.Products.Handler.CommandHandler;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, ResponseModel<UpdateProductCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<UpdateProductCommandResponse>> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id);
        if (product == null)
        {
            return new ResponseModel<UpdateProductCommandResponse>(null);
        }

        product.Name = request.Name;
        product.Price = request.Price;
        product.CategoryId = request.CategoryId;

        _unitOfWork.ProductRepository.UpdateAsync(product);
        await _unitOfWork.Save();

        var response = new UpdateProductCommandResponse
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            CategoryId = product.CategoryId
        };

        return new ResponseModel<UpdateProductCommandResponse>(response);
    }
}