using AutoMapper;
using CarAccessoriesShop.Application.DTOs.Contact.QueryDtos;
using CarAccessoriesShop.Application.Exceptions;
using CarAccessoriesShop.Application.Features.Contact.Requests.Queries;
using CarAccessoriesShop.Application.Presistences.UnitofWork;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Contact.Handlers.Queries;

internal class FindPersonContactsRequestHandler(IUnitofWork unitofWork, IMapper mapper) : IRequestHandler<FindPersonContactsRequest, IEnumerable<ShowPersonContactDto>>
{
    async Task<IEnumerable<ShowPersonContactDto>> IRequestHandler<FindPersonContactsRequest, IEnumerable<ShowPersonContactDto>>.Handle(FindPersonContactsRequest request, CancellationToken cancellationToken)
    {
        var contacts = await unitofWork.ContactRepo.FindMultiRowsBy(x => x.PersonID == request.PersonID, x => x.Id, x => x.Country);
        if (contacts == null || !contacts.Any())
        {
            throw new NotFoundException($"No contacts found for person with ID {request.PersonID}");
        }
        return mapper.Map<IEnumerable<ShowPersonContactDto>>(contacts);
    }
}
