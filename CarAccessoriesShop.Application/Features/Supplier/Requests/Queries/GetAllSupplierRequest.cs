using CarAccessoriesShop.Application.DTOs.Supplier.Query;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Supplier.Requests.Queries;

public class GetAllSupplierRequest : IRequest<IEnumerable<SupplierWithContactDto>>
{
}
