using AutoMapper;
using CarAccessoriesShop.Application.DTOs.Supplier.CommandDtos;
using CarAccessoriesShop.Application.DTOs.Supplier.Query;
using CarAccessoriesShop.Domain.Entity.HR;

namespace CarAccessoriesShop.Application.Profiles;

internal class SupplierProfile : Profile
{
    public SupplierProfile()
    {
        // Map From InsertSupplierDto to Supplier
        CreateMap<InsertSupplierDto, Supplier>();

        // Map From UpdateSupplierDto to Supplier
        CreateMap<UpdateSupplierDto, Supplier>()
            .ForMember(des=> des.Id , opt=> opt.Ignore())
            .ForMember(des => des.PersonContactID, opt => opt.Ignore());

        // Map From Supplier to SupplierDto
        CreateMap<Supplier, SupplierDto>();
    }
}
