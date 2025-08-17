using CarAccessoriesShop.Application.DTOs.Contact;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Contact.Requests.Commands;

public record InsertContactRequest(CreatContactDto Contact) : IRequest<RequestContactDto>
{
    
}

public record InsertListContactRequest(IList<CreatContactDto> Contacts) : IRequest<List<RequestContactDto>>
{
    
}