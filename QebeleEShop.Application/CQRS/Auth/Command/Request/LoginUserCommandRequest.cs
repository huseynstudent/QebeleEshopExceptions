using MediatR;
using QebeleEShop.Application.CQRS.Auth.Command.Response;
using QebeleEShop.Common.GlobalResponse;

namespace QebeleEShop.Application.CQRS.Auth.Command.Request;

public class LoginUserCommandRequest:IRequest<ResponseModel<LoginUserCommandResponse>>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
