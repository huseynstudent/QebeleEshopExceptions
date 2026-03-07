using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QebeleEShop.Application.CQRS.Categories.Command.Request;
using QebeleEShop.Application.CQRS.Categories.Query.Request;
using QebeleEShop.WebApi.Constants;

namespace QebeleEShop.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = $"{UserRoles.Admin},{UserRoles.Customer}")]
public class CategoryController : BaseController
{
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryCommandRequest request)
    {
        return Ok(await Sender.Send(request));
    }
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAllCategories([FromQuery] GetAllCategoryQueryRequest request)
    {
        return Ok(await Sender.Send(request));
    }
    [AllowAnonymous]
    [HttpPut]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryCommandRequest request)
    {
        return Ok(await Sender.Send(request));
    }
    [AllowAnonymous]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        return Ok(await Sender.Send(new DeleteCategoryCommandRequest { Id = id }));

    }
    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        return Ok(await Sender.Send(new GetCategoryByIdQueryRequest { Id = id }));
    }
    }
