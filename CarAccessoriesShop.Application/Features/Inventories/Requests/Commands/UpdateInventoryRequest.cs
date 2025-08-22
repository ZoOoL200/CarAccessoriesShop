using CarAccessoriesShop.Application.DTOs.Invertory.CommandDtos;
using CarAccessoriesShop.Application.DTOs.Invertory.QueryDtos;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Inventories.Requests.Commands;

public class UpdateInventoryRequest(UpdateInventoryDto inventoryDto) : IRequest<InventoryDto>
{
    public UpdateInventoryDto Inventory { get; } = inventoryDto;
}
