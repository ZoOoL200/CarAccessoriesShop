using AutoMapper;
using CarAccessoriesShop.Application.DTOs.Category.CommandDtos;
using CarAccessoriesShop.Application.DTOs.Category.QueryDtos;
using CarAccessoriesShop.Domain.Entity.Main;

namespace CarAccessoriesShop.Application.Profiles;

internal class CategoryProfile :Profile
{
    public CategoryProfile()
    {
        // Mapp from InsertCategoryDto to Category entity
        CreateMap<InsertCategoryDto, Category>()
            .ForMember(des => des.Products, opt => opt.Ignore())
            .ForMember(des => des.Id, opt => opt.Ignore());


        // Map from UpdateCategoryDto to Category entity
        CreateMap<UpdateCategoryDto,Category>()
            .ForMember(des=>des.Products , opt=> opt.Ignore())
            .ForMember(des => des.Id, opt => opt.Ignore())
            .ForMember(des => des.Title, opt => opt.MapFrom((src,des)=> src.Title?? des.Title))
            .ForMember(des => des.Description, opt => opt.MapFrom((src,des)=> src.Description == null ? des.Description 
            : string.IsNullOrWhiteSpace(src.Description)? null : src.Description));
        // map from Category entity to CategoryDto
        CreateMap<Category,CategoryDto>();
    }
}
