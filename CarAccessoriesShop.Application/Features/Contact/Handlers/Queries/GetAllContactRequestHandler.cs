using AutoMapper;
using CarAccessoriesShop.Application.DTOs.Contact.QueryDtos;
using CarAccessoriesShop.Application.Features.Contact.Requests.Queries;
using CarAccessoriesShop.Application.Presistences.UnitofWork;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Contact.Handlers.Queries;

internal class GetAllContactRequestHandler(IUnitofWork unitofWork, IMapper mapper) : IRequestHandler<GetAllContactRequest, IEnumerable<ShowContactDto>>
{
    async Task<IEnumerable<ShowContactDto>> IRequestHandler<GetAllContactRequest, IEnumerable<ShowContactDto>>.Handle(GetAllContactRequest request, CancellationToken cancellationToken)
    {
        var contacts = await unitofWork.ContactRepo.GetAllAsync(x=> x.Id, x=>x.Country, x=>x.Person);
        return   mapper.Map<IEnumerable<ShowContactDto>>(contacts);
    }
}

