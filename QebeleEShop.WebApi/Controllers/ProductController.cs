using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QebeleEShop.Application.CQRS.Products.Command.Request;
using QebeleEShop.Application.CQRS.Products.Query.Request;
using QebeleEShop.WebApi.Constants;

namespace QebeleEShop.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = $"{UserRoles.Admin}")]
public class ProductController : BaseController
{

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductCommandRequest request)
    {
        return Ok(await Sender.Send(request));
    }
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAllProducts([FromQuery] GetAllProductQueryRequest request)
    {
        return Ok(await Sender.Send(request));
    }
    [AllowAnonymous]
    [HttpPut]
    public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest request)
    {
        return Ok(await Sender.Send(request));
    }
    [AllowAnonymous]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        return Ok(await Sender.Send(new DeleteProductCommandRequest { Id = id }));
    }
    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        return Ok(await Sender.Send(new GetProductByIdQueryRequest { Id = id }));
    }

    }
