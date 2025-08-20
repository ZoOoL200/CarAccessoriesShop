using CarAccessoriesShop.Application.DTOs.Supplier.CommandDtos;
using CarAccessoriesShop.Application.DTOs.Supplier.Query;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Supplier.Requests.Commands;

public class CreateSupplierRequest (InsertSupplierDto Supplier) :IRequest<SupplierDto>
{
    public InsertSupplierDto Supplier { get; set; } = Supplier;
}
