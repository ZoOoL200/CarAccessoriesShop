using CarAccessoriesShop.Application.DTOs.Contact.CommandDtos;
using CarAccessoriesShop.Application.Features.Contact.Requests.Commands;
using CarAccessoriesShop.Application.Features.Contact.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarAccessoriesShop.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController(IMediator mediator) : ControllerBase
{
    // Insert a new contact
    [HttpPost]
    [Route("NewContact")]
    public async Task<IActionResult> CreateContact([FromBody] CreatContactDto request)
    {

        var result = await mediator.Send(new InsertContactRequest(request));
        return Ok(result);

    }

    // Insert a list of contacts
    [HttpPost]
    [Route("NewListContact")]
    public async Task<IActionResult> CreateListContact([FromBody] IList<CreatContactDto> request)
    {

        var result = await mediator.Send(new InsertListContactRequest(request));
        return Ok(result);
    }


    // Update an existing contact
    [HttpPut]
    [Route("UpdateContact")]
    public async Task<IActionResult> UpdateContact([FromBody] UpdateContactDto request)
    {
        var result = await mediator.Send(new UpdateContactRequest(request));
        return Ok(result);
    }

    // Update a list of contacts
    [HttpPut]
    [Route("UpdateListContact")]
    public async Task<IActionResult> UpdateListContact([FromBody] IList<UpdateContactDto> request)
    {
        var result = await mediator.Send(new UpdateListContactRequest(request));
        return Ok(result);
    }

    //Get all contacts
    [HttpGet]
    [Route("GetAllContact")]
    public async Task<IActionResult> GetAllContact()
    {
        var result = await mediator.Send(new GetAllContactRequest());
        return Ok(result);
    }

    // Get Contacts For Person
    [HttpGet]
    [Route("GetPersonContacts/{personId}")]
    public async Task<IActionResult> GetPersonContacts(Guid personId)
    {
        var result = await mediator.Send(new FindPersonContactsRequest(personId));
        return Ok(result);
    }
}
