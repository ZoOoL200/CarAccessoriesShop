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
            .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.Person.PersonName))
            .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.CountryName))
            .ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.Country.Key));

        // Map from UpdateContactDto to Contact
        CreateMap<UpdateContactDto, Contact>()
            .ForMember(dest => dest.CountryID, opt => opt.Ignore())
            .ForMember(dest => dest.Country, opt => opt.Ignore())
            .ForMember(dest => dest.Person, opt => opt.Ignore())
            .ForMember(dest => dest.PersonID, opt => opt.Ignore());

        // Map from CreateContactDto to Contact
        CreateMap<CreatContactDto, Contact>()
            .ForMember(dest=> dest.CountryID, opt=> opt.Ignore())
            .ForMember(dest => dest.Country, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore())
             .ForMember(dest => dest.Person, opt => opt.Ignore());
       
    }
}
