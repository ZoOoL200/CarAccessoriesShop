using CarAccessoriesShop.Application.DTOs.Invertory.CommandDtos;
using CarAccessoriesShop.Application.DTOs.Invertory.QueryDtos;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Inventories.Requests.Commands;

public class InsertInventoryRequest(InsertInvetoryDto invetoryDto) : IRequest<InventoryDto>
{
    public InsertInvetoryDto Invetory { get; } = invetoryDto;
}
