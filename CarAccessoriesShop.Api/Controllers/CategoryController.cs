using CarAccessoriesShop.Application.DTOs.Category.CommandDtos;
using CarAccessoriesShop.Application.Features.Categories.Requests.Commands;
using CarAccessoriesShop.Application.Features.Categories.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarAccessoriesShop.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController(IMediator mediator) : ControllerBase
{
    // Get All Categories
    [HttpGet]
    [Route("GetAllCategories")]
    public async Task<IActionResult> GetAllCategories()
    {
        var result = await mediator.Send(new GetAllCategoryRequest());
        return Ok(result);
    }

    // Get Category by Id
    [HttpGet]
    [Route("GetCategoryById/{id}")]
    public async Task<IActionResult> GetCategoryById(Guid id)
    {
        var result = await mediator.Send(new GetOneCategoryRequest(id));
        return Ok(result);
    }

    // Insert New Category
    [HttpPost]
    [Route("NewCategory")]
    public IActionResult NewCategory([FromBody] InsertCategoryDto request)
    {
        var result = mediator.Send(new InsertCategoryRequest(request));
        return Ok(result);
    }

    // Update Existing Category
    [HttpPatch]
    [Route("UpdateCategory")]
    public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryDto request)
    {
        var result = await mediator.Send(new UpdateCategoryRequest(request));
        return Ok(result);
    }
}
