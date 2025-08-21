using AutoMapper;
using CarAccessoriesShop.Application.DTOs.Branch.CommandDtos;
using CarAccessoriesShop.Application.DTOs.Branch.QueryDtos;
using CarAccessoriesShop.Domain.Entity.Main;

namespace CarAccessoriesShop.Application.Profiles
{
    internal class BranchProfile : Profile
    {
        public BranchProfile()
        {
            // Mapp InsertBranchDto to Branch
            CreateMap<InsertBranchDto, Branch>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Inventories, opt => opt.Ignore())
                .ForMember(dest => dest.PurchaseInvoices, opt => opt.Ignore())
                .ForMember(dest => dest.SalesInvoices, opt => opt.Ignore());
            // Map UpdateBranchDto to Branch and Reverse
            CreateMap<UpdateBranchDto, Branch>()
                .ForMember(dest => dest.Inventories, opt => opt.Ignore())
                .ForMember(dest => dest.PurchaseInvoices, opt => opt.Ignore())
                .ForMember(dest => dest.SalesInvoices, opt => opt.Ignore())
                .ForMember(dest => dest.Location, opt =>
                {
                    opt.MapFrom((src, dest) =>
                        src.Location == null? dest.Location   
                        : string.IsNullOrWhiteSpace(src.Location) ? null : src.Location);
                });
            // Map Branch to BranchDto
            CreateMap<Branch, BranchDto>();
        }
    }
}
