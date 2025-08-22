using AutoMapper;
using CarAccessoriesShop.Application.DTOs.Invertory.QueryDtos;
using CarAccessoriesShop.Application.Features.Inventories.Requests.Query;
using CarAccessoriesShop.Application.Presistences.UnitofWork;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Inventories.Handlers.Query;

internal class GetAllInventoriesRequestHandler(IUnitofWork unitofWork, IMapper mapper) : IRequestHandler<GetAllInventoriesRequest, List<InventoryDto>>
{
    public async Task<List<InventoryDto>> Handle(GetAllInventoriesRequest request, CancellationToken cancellationToken)
    {
        var inventories = await unitofWork.InventoryRepo.GetAllAsync(x=>x.Id);
        return mapper.Map<List<InventoryDto>>(inventories);
    }
}
