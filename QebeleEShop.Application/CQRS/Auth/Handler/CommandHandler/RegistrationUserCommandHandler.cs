using MediatR;
using QebeleEShop.Application.CQRS.Auth.Command.Request;
using QebeleEShop.Application.CQRS.Auth.Command.Response;
using QebeleEShop.Common.GlobalResponse;
using QebeleEShop.Domain.Entities;
using QebeleEShop.Domain.Extensions;
using QebeleEShop.Repository.Common;

namespace QebeleEShop.Application.CQRS.Auth.Handler.CommandHandler;

public class RegistrationUserCommandHandler : IRequestHandler<RegistrationUserCommandRequest, ResponseModel<RegistrationUserCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public RegistrationUserCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<RegistrationUserCommandResponse>> Handle(RegistrationUserCommandRequest request, CancellationToken cancellationToken)
    {
        var hassedPassword = PasswordHasher.HashPassword(request.Password);
        var user = new User()
        {
            Name = request.Name,
            Surname = request.Surname,
            Email = request.Email,
            PasswordHash = hassedPassword,
            CreatedDate = DateTime.UtcNow,
            UserType = request.UserType
        };
        _unitOfWork.UserRepository.RegisterAsync(user);
        _unitOfWork.Save();
        var response = new RegistrationUserCommandResponse()
        {
            Id = user.Id,
            Name = user.Name,
            Surname = user.Surname,
            Email = user.Email,
            UserType = user.UserType
        };
        return new ResponseModel<RegistrationUserCommandResponse>(response);
    }
}
