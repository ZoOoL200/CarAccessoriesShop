using CarAccessoriesShop.Application.DTOs.Supplier.Query;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Supplier.Requests.Queries;

public class GetOneSupplierRequest(Guid Id) : IRequest<SupplierWithContactDto>
{
    public Guid Id { get; set; } = Id;
}
