using CarAccessoriesShop.Application.DTOs.Contact.CommandDtos;
using CarAccessoriesShop.Application.DTOs.Contact.QueryDtos;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Contact.Requests.Commands;

public record UpdateContactRequest(UpdateContactDto ContactDto): IRequest<ShowContactDto>
{

}

public record UpdateListContactRequest(IList<UpdateContactDto> Contacts) : IRequest<List<ShowContactDto>>
{

}


