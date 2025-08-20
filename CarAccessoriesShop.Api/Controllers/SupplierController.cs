using CarAccessoriesShop.Application.DTOs.Supplier.CommandDtos;
using CarAccessoriesShop.Application.Features.Supplier.Requests.Commands;
using CarAccessoriesShop.Application.Features.Supplier.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarAccessoriesShop.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SupplierController(IMediator mediator) : ControllerBase
{
    // Endpoint to create a new supplier
    [HttpPost]
    [Route("CreateSupplier")]
    public async Task<IActionResult> CreateSupplier([FromBody] InsertSupplierDto supplier)
    {
        var result = await mediator.Send(new CreateSupplierRequest(supplier));
        return Ok(result);
    }

    // Endpoint to update an existing supplier
    [HttpPatch]
    [Route("UpdateSupplier")]
    public async Task<IActionResult> UpdateSupplier([FromBody] UpdateSupplierDto supplier)
    {
        var result = await mediator.Send(new UpdateSupplierRequest(supplier));
        return Ok(result);
    }

    // Endpoint to Get a suppliers 
    [HttpGet]
    [Route("GetAllSuppliers")]
    public async Task<IActionResult> GetAllSuppliers()
    {
        var result = await mediator.Send(new GetAllSupplierRequest());
        return Ok(result);
    }

    // Endpoint to Get a supplier by ID
    [HttpGet]
    [Route("GetOneSupplier/{id}")]
    public async Task<IActionResult> GetOneSupplier(Guid id)
    {
        var result = await mediator.Send(new GetOneSupplierRequest(id));
        return Ok(result);
    }
}
