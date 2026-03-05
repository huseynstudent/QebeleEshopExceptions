namespace QebeleEShop.Application.CQRS.Auth.Command.Response;

public class LoginUserCommandResponse
{
    public string Token { get; set; }
    public DateTime ExpiredDate { get; set; }
}
