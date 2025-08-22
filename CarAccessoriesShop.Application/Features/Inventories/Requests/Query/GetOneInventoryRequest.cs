using CarAccessoriesShop.Application.DTOs.Invertory.QueryDtos;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Inventories.Requests.Query;

public class GetOneInventoryRequest(Guid Id) : IRequest<InventoryDto>
{
    public Guid Id { get; } = Id;
}
