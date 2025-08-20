using CarAccessoriesShop.Application.DTOs.Contact.CommandDtos;
using CarAccessoriesShop.Application.DTOs.Contact.QueryDtos;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Contact.Requests.Commands;

public record InsertContactRequest(CreatContactDto Contact) : IRequest<ShowContactDto>
{
    
}

public record InsertListContactRequest(IList<CreatContactDto> Contacts) : IRequest<List<ShowContactDto>>
{
    
}