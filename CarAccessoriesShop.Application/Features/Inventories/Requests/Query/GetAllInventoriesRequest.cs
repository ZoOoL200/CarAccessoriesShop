using CarAccessoriesShop.Application.DTOs.Invertory.QueryDtos;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Inventories.Requests.Query;

public class GetAllInventoriesRequest : IRequest<List<InventoryDto>>
{
}
