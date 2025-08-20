using CarAccessoriesShop.Application.DTOs.Contact.QueryDtos;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Contact.Requests.Queries;

public class GetAllContactRequest : IRequest<IEnumerable<ShowContactDto>>
{
}
