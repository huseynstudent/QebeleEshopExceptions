using MediatR;
using QebeleEShop.Application.CQRS.Auth.Command.Response;
using QebeleEShop.Common.GlobalResponse;
using QebeleEShop.Domain.Enums;

namespace QebeleEShop.Application.CQRS.Auth.Command.Request;

public class RegistrationUserCommandRequest:IRequest<ResponseModel<RegistrationUserCommandResponse>>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserType UserType { get; set; }
}
