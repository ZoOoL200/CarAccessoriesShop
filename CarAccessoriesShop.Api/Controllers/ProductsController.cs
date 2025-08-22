using CarAccessoriesShop.Application.DTOs.Product.CommandDtos;
using CarAccessoriesShop.Application.Features.Products.Requests.Commands;
using CarAccessoriesShop.Application.Features.Products.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CarAccessoriesShop.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IMediator mediator) : ControllerBase
{
    // Endpoint for getting a product by its ID
    [HttpGet]
    [Route("GetAllProducts")]
    public async Task<IActionResult> GetAllProducts()
    {
        var result = await mediator.Send(new GetAllProductRequest());
        return Ok(result);
    }

    // Endpoint for getting a product by its ID
    [HttpGet]
    [Route("GetProductById/{id}")]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        var result = await mediator.Send(new GetOneProductRequest(id));
        return Ok(result);
    }

    // Endpoint for getting products by category ID
    [HttpGet]
    [Route("GetProductsByCategoryId/{categoryId}")]
    public async Task<IActionResult> GetProductsByCategoryId(short categoryId)
    {
        var result = await mediator.Send(new GetProductsByCategoryRequest(categoryId));
        return Ok(result);
    }

    // Enidpoint for creating a new product
    [HttpPost]
    [Route("NewProduct")]
    public async Task<IActionResult> CreateProduct([FromBody] InsertProductDto request)
    {
        var result = await mediator.Send(new InsertProductRequest(request));
        return Ok(result);
    }

    // Einpoint for updating an existing product
    [HttpPut]
    [Route("UpdateProduct")]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDto request)
    {
        var result = await mediator.Send(new UpdateProductRequest(request));
        return Ok(result);
    }

}
