using CarAccessoriesShop.Application.DTOs.Supplier.CommandDtos;
using CarAccessoriesShop.Application.DTOs.Supplier.Query;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Supplier.Requests.Commands
{
    public class UpdateSupplierRequest(UpdateSupplierDto supplier) : IRequest<SupplierDto>
    {
        public UpdateSupplierDto Supplier { get; set; } = supplier;
    }
}
