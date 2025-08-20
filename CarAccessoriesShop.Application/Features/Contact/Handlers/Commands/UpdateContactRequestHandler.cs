using AutoMapper;
using CarAccessoriesShop.Application.DTOs.Contact.QueryDtos;
using CarAccessoriesShop.Application.Exceptions;
using CarAccessoriesShop.Application.Features.Contact.Requests.Commands;
using CarAccessoriesShop.Application.Presistences.UnitofWork;
using CarAccessoriesShop.Domain.Entity.HR;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Contact.Handlers.Commands;

public class UpdateContactRequestHandler(IUnitofWork unitofWork, IMapper mapper) : IRequestHandler<UpdateContactRequest, ShowContactDto>
{
     public async Task<ShowContactDto> Handle(UpdateContactRequest request, CancellationToken cancellationToken)
     {
        // Attempt to retrieve the existing contact by ID and update it
        var contact = await unitofWork.ContactRepo.GetByIdAsync(request.ContactDto.Id) 
            ?? throw new NotFoundException(nameof(Contact), request.ContactDto.Id);


        // Attempt to retrieve the country by key and set the CountryID
        var country = await unitofWork.CountryKeyRepo.FindRowBy(x => x.Key == request.ContactDto.Key)
            ?? throw new NotFoundException(nameof(CountryKey), request.ContactDto.Key);

        contact!.CountryID = country.Id;

        // Map the request DTO to the contact entity
        mapper.Map(request.ContactDto, contact);
        await unitofWork.SaveChangesAsync(cancellationToken);

        // Retrieve the updated contact entity with related data
        var returnedContact = await unitofWork.ContactRepo.FindRowBy(X => X.Id == contact.Id, x => x.Country, x => x.Person);
        return mapper.Map<ShowContactDto>(returnedContact);
    }
}

public class UpdateListContactRequestHandler(IUnitofWork unitofWork, IMapper mapper) : IRequestHandler<UpdateListContactRequest, List<ShowContactDto>>
{

    public async Task<List<ShowContactDto>> Handle(UpdateListContactRequest request, CancellationToken cancellationToken)
    {
        // Create a list to hold the contact entities
        var keys = request.Contacts.Select(x => x.Key).Distinct().ToList();

        // Gert dictionary of countries based on the keys
        var countries = await unitofWork.CountryKeyRepo.FindMultiRowsBy(c => keys.Contains(c.Key));
        var countriesDic = countries.ToDictionary(c => c.Key, c => c.Id);

        // Retrieve existing contacts from the database based on the IDs in the request and create a dictionary for quick access
        var existingContacts = await unitofWork.ContactRepo.FindMultiRowsBy(c => request.Contacts.Select(x => x.Id).Contains(c.Id));
        var ContactsDic = existingContacts.ToDictionary(c => c.Id, c => c);

        // Update each contact entity with the corresponding CountryID
        foreach (var contact in request.Contacts)
        {
            if (!ContactsDic.TryGetValue(contact.Id, out var existingContact))
                throw new NotFoundException(nameof(Contact), contact.Id);

            if (!countriesDic.TryGetValue(contact.Key!, out var countryId))
                throw new NotFoundException(nameof(CountryKey), contact.Key);

            existingContact.CountryID = countryId;
            mapper.Map(contact, existingContact);
        }
        // Save changes to the database
        await unitofWork.SaveChangesAsync(cancellationToken);
        var ids = request.Contacts.Select(c => c.Id).ToList();
        var returendContact = await unitofWork.ContactRepo.FindMultiRowsBy(x => ids.Contains(x.Id), x => x.Country, x => x.Person);
        return mapper.Map<List<ShowContactDto>>(returendContact);

    }
}
