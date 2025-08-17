using CarAccessoriesShop.Application.DTOs.Contact;
using CarAccessoriesShop.Application.Features.Contact.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarAccessoriesShop.Api.Controllers.Contacts;

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
}
