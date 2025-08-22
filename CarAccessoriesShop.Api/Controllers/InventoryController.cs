using CarAccessoriesShop.Application.DTOs.Invertory.CommandDtos;
using CarAccessoriesShop.Application.Features.Inventories.Requests.Commands;
using CarAccessoriesShop.Application.Features.Inventories.Requests.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarAccessoriesShop.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InventoryController(IMediator mediator) : ControllerBase
{
    // Enpoint for GetAllInventories
    [HttpGet]
    [Route("GetAllInventories")]
    public async Task<IActionResult> GetAllInventories(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetAllInventoriesRequest(), cancellationToken);
        return Ok(result);
    }
    // Endpoint for GetInventoryById
    [HttpGet]
    [Route("GetInventoryById/{id}")]
    public async Task<IActionResult> GetInventoryById(Guid id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetOneInventoryRequest(id), cancellationToken);
        return Ok(result);
    }
    // Endpoint for InsertInventory
    [HttpPost]
    [Route("NewInventory")]
    public async Task<IActionResult> InsertInventory([FromBody] InsertInvetoryDto invetoryDto, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new InsertInventoryRequest(invetoryDto), cancellationToken);
        return Ok(result);
    }

    // Endpoint for UpdateInventory
    [HttpPatch]
    [Route("UpdateInventory")]
    public async Task<IActionResult> UpdateInventory([FromBody] UpdateInventoryDto inventoryDto, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateInventoryRequest(inventoryDto), cancellationToken);
        return Ok(result);
    }
}
