using CarAccessoriesShop.Application.DTOs.Supplier.CommandDtos;
using CarAccessoriesShop.Application.Features.Supplier.Requests.Commands;
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
        // Assuming you have a mediator instance injected
        var result = await mediator.Send(new CreateSupplierRequest(supplier));
        return Ok(result);
    }
}
