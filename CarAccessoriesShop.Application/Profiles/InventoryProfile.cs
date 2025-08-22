using AutoMapper;
using CarAccessoriesShop.Application.DTOs.Invertory.CommandDtos;
using CarAccessoriesShop.Application.DTOs.Invertory.QueryDtos;
using CarAccessoriesShop.Domain.Entity.Main;

namespace CarAccessoriesShop.Application.Profiles;

internal class InventoryProfile : Profile
{
    public InventoryProfile()
    {
        // CreateMap<Source, Destination>();
        // map from InsertInvetoryDto to Inventory
        CreateMap<InsertInvetoryDto, Inventory>()
            .ForMember(des=> des.Id, opt=> opt.Ignore())
            .ForMember(des => des.Branch, opt => opt.Ignore())
            .ForMember(des => des.ProductStocks, opt => opt.Ignore());

        // map from UpdateInventoryDto to Inventory
        CreateMap<UpdateInventoryDto, Inventory>()
            .ForMember(des=> des.Id, opt => opt.Ignore())
            .ForMember(des => des.Branch, opt => opt.Ignore())
            .ForMember(des => des.ProductStocks, opt => opt.Ignore())
            .ForMember(des => des.Title, opt => opt.MapFrom((src, des) => src.Title ?? des.Title));
        // map from Inventory to InvetoryDto
        CreateMap<Inventory, InventoryDto>();
    }
}
