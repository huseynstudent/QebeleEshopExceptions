using MediatR;
using Microsoft.Extensions.Configuration;
using QebeleEShop.Application.CQRS.Auth.Command.Request;
using QebeleEShop.Application.CQRS.Auth.Command.Response;
using QebeleEShop.Common.GlobalResponse;
using QebeleEShop.Domain.Extensions;
using QebeleEShop.Domain.Helper;
using QebeleEShop.Repository.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace QebeleEShop.Application.CQRS.Auth.Handler.CommandHandler;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, ResponseModel<LoginUserCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _configuration;

    public LoginUserCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _configuration = configuration;
    }

    public async Task<ResponseModel<LoginUserCommandResponse>> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
    {
        var loginProvider = Guid.NewGuid().ToString();
        var user = await _unitOfWork.UserRepository.GetByEmailAsync(request.Email);
        var hassedPassword = PasswordHasher.HashPassword(request.Password);


        if (user.PasswordHash != hassedPassword)
        {
            throw new Exception("Yalnis password");
        }
        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim("loginProvider", loginProvider),
            new Claim(ClaimTypes.Role, user.UserType.ToString())
        };
        var token = TokenService.CreateToken(authClaims, _configuration);
        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        var response = new LoginUserCommandResponse
        {
            Token = tokenString,
            ExpiredDate = token.ValidTo
        };
        return new ResponseModel<LoginUserCommandResponse>(response);
    }
}
