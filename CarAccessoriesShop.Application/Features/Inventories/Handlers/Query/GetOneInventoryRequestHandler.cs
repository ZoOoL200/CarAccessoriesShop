using AutoMapper;
using CarAccessoriesShop.Application.DTOs.Invertory.QueryDtos;
using CarAccessoriesShop.Application.Exceptions;
using CarAccessoriesShop.Application.Features.Inventories.Requests.Query;
using CarAccessoriesShop.Application.Presistences.UnitofWork;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Inventories.Handlers.Query;

internal class GetOneInventoryRequestHandler(IUnitofWork unitofWork, IMapper mapper) : IRequestHandler<GetOneInventoryRequest, InventoryDto>
{
    public async Task<InventoryDto> Handle(GetOneInventoryRequest request, CancellationToken cancellationToken)
    {
        var inventory = await unitofWork.InventoryRepo.GetByIdAsync(request.Id) 
            ?? throw new NotFoundException($"Inventory with Id {request.Id} not found.");
        return mapper.Map<InventoryDto>(inventory);
    }
}
