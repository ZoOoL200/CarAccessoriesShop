using AutoMapper;
using CarAccessoriesShop.Application.DTOs.Contact;
using CarAccessoriesShop.Domain.Entity.HR;

namespace CarAccessoriesShop.Application.Profiles;

internal class ContactProfile : Profile
{
    public ContactProfile()
    {
        // Map from Contact to RequestContactDto
        CreateMap<Contact, RequestContactDto>()
            .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.person.PersonName))
            .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.CountryName))
            .ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.Country.Key));

        // Map from CreateContactDto to Contact
        CreateMap<CreatContactDto, Contact>()
            .ForMember(dest=> dest.CountryID, opt=> opt.Ignore())
            .ForMember(dest => dest.Country, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore())
             .ForMember(dest => dest.person, opt => opt.Ignore());
       
    }
}
