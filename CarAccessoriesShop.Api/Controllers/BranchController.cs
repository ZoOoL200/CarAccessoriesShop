using CarAccessoriesShop.Application.DTOs.Branch.CommandDtos;
using CarAccessoriesShop.Application.Features.Branch.Requests.Commands;
using CarAccessoriesShop.Application.Features.Branch.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarAccessoriesShop.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BranchController(IMediator mediator) : ControllerBase
{
    // Endpoint to create a new branch
    [HttpPost]
    [Route("CreateBranch")]
    public async Task<IActionResult> CreateBranch([FromBody] InsertBranchDto branch)
    {
        var result = await mediator.Send(new InsertBranchRequest(branch));
        return Ok(result);
    }

    // Endpoint to update an existing branch
    [HttpPatch]
    [Route("UpdateBranch")]
    public async Task<IActionResult> UpdateBranch([FromBody] UpdateBranchDto branch)
    {
        var result = await mediator.Send(new UpdateBranchRequest(branch));
        return Ok(result);
    }

    // Endpoint to get All branchs
    [HttpGet]
    [Route("GetAllBranches")]
    public async Task<IActionResult> GetAllBranches()
    {
        var result = await mediator.Send(new GetAllBranchsRequest());
        return Ok(result) ;
    }

    // Endpoint to get a branch by ID
    [HttpGet]
    [Route("GetBranchById/{id}")]
    public async Task<IActionResult> GetBranchById(Guid id)
    {
        var result = await mediator.Send(new GetOneBranchRequest(id));
        return Ok(result);
    }
}
