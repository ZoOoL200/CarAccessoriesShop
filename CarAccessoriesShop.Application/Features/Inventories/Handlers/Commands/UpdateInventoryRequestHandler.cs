using AutoMapper;
using CarAccessoriesShop.Application.DTOs.Invertory.QueryDtos;
using CarAccessoriesShop.Application.Exceptions;
using CarAccessoriesShop.Application.Features.Inventories.Requests.Commands;
using CarAccessoriesShop.Application.Presistences.UnitofWork;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Inventories.Handlers.Commands;

internal class UpdateInventoryRequestHandler(IUnitofWork unitofWork, IMapper mapper) : IRequestHandler<UpdateInventoryRequest, InventoryDto>
{
    public async Task<InventoryDto> Handle(UpdateInventoryRequest request, CancellationToken cancellationToken)
    {
        // Check if the inventory exists
        var existingInventory = unitofWork.InventoryRepo.GetByIdAsync(request.Inventory.Id)
            ?? throw new NotFoundException($"Inventory with Id {request.Inventory.Id} not found.");
        // Map the updated fields from the DTO to the existing inventory entity
        await mapper.Map(request.Inventory, existingInventory);
        // Update the inventory in the repository
        await unitofWork.SaveChangesAsync(cancellationToken);
        // return the updated inventory as a DTO
        return mapper.Map<InventoryDto>(existingInventory);
    }
}
