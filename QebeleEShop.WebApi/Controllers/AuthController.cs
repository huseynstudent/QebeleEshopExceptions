using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QebeleEShop.Application.CQRS.Auth.Command.Request;

namespace QebeleEShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("Registration")]
        public async Task<IActionResult> Registration(RegistrationUserCommandRequest request)
        {
            return Ok(await Sender.Send(request));
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserCommandRequest request)
        {
            return Ok(await Sender.Send(request));
        }
    }
}
