using CarAccessoriesShop.Application.DTOs.Contact.QueryDtos;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Contact.Requests.Queries
{
    public class FindPersonContactsRequest (Guid Person) : IRequest<IEnumerable<ShowPersonContactDto>>
    {
        public Guid PersonID => Person;
    }
}
