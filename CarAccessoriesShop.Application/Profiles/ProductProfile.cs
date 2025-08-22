using AutoMapper;
using CarAccessoriesShop.Application.DTOs.Product.CommandDtos;
using CarAccessoriesShop.Application.DTOs.Product.QueryDtos;
using CarAccessoriesShop.Domain.Entity.Main;

namespace CarAccessoriesShop.Application.Profiles;

internal class ProductProfile : Profile
{
    public ProductProfile()
    {
        // Map InsertProductDto to Product
        CreateMap<InsertProductDto, Product>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.ProductStocks, opt => opt.Ignore())
            .ForMember(dest => dest.PurchaseDetails, opt => opt.Ignore())
            .ForMember(dest => dest.SalesDetails, opt => opt.Ignore())
            .ForMember(dest => dest.Category, opt => opt.Ignore());

        // Map UpdateProductDto to Product
        CreateMap<UpdateProductDto, Product>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.ProductStocks, opt => opt.Ignore())
            .ForMember(dest => dest.PurchaseDetails, opt => opt.Ignore())
            .ForMember(dest => dest.SalesDetails, opt => opt.Ignore())
            .ForMember(dest => dest.Category, opt => opt.Ignore())
            .ForMember(dest => dest.CategoryID, opt => opt.Ignore()) // Ignore CategoryID to prevent overwriting
            .ForMember(dest => dest.Title, opt => opt.MapFrom((src, dest) => src.Title?? dest.Title))
            .ForMember(dest=> dest.Description, opt=> { opt.MapFrom((src, des)=>
            src.Description == null? des.Description 
            : string.IsNullOrWhiteSpace(src.Description)? null : src.Description); });

        // Map Product to ProductDto
        CreateMap<Product, ProductDto>()
            .ForMember(dest=> dest.CategoryName, opt=> opt.MapFrom(src=> src.Category.Title));
    }
}
