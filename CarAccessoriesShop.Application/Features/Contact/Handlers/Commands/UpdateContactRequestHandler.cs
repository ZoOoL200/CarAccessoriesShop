using AutoMapper;
using CarAccessoriesShop.Application.DTOs.Contact;
using CarAccessoriesShop.Application.DTOs.Contact.Validtors;
using CarAccessoriesShop.Application.Exceptions;
using CarAccessoriesShop.Application.Features.Contact.Requests.Commands;
using CarAccessoriesShop.Application.Presistences.UnitofWork;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CarAccessoriesShop.Application.Features.Contact.Handlers.Commands;

public class UpdateContactRequestHandler(IUnitofWork unitofWork, IMapper mapper) : IRequestHandler<UpdateContactRequest, RequestContactDto>
{
     public async Task<RequestContactDto> Handle(UpdateContactRequest request, CancellationToken cancellationToken)
     {

        // Map the request data to a domain entity
        var contactEntity = mapper.Map<CarAccessoriesShop.Domain.Entity.HR.Contact>(request.ContactDto);

        // Attempt to retrieve the country by key and set the CountryID
        var country = await unitofWork.CountryKeyRepo.FindRowBy(x => x.Key == request.ContactDto.Key);
        contactEntity.CountryID = country.Id;

        // Attempt to retrieve the existing contact by ID and update it
        var contact = await unitofWork.ContactRepo.GetByIdAsync(contactEntity.Id);
        mapper.Map(contactEntity, contact);
        await unitofWork.SaveChangesAsync(cancellationToken);

        // Retrieve the updated contact entity with related data
        var returnedContact = await unitofWork.ContactRepo.FindRowBy(X => X.Id == contactEntity.Id, x => x.Country, x => x.Person);
        return mapper.Map<RequestContactDto>(returnedContact);
    }
}

public class UpdateListContactRequestHandler(IUnitofWork unitofWork, IMapper mapper) : IRequestHandler<UpdateListContactRequest, List<RequestContactDto>>
{

    public async Task<List<RequestContactDto>> Handle(UpdateListContactRequest request, CancellationToken cancellationToken)
    {
        // Create a list to hold the contact entities
        var keys = request.Contacts.Select(x => x.Key).Distinct().ToList();

        // Gert dictionary of countries based on the keys
        var countries = await unitofWork.CountryKeyRepo.FindMultiRowsBy(c => keys.Contains(c.Key));
        var countriesDic = countries.ToDictionary(c => c.Key, c => c.Id);

        // Update each contact entity with the corresponding CountryID
        foreach (var contact in request.Contacts)
        {
            var contactEntity = mapper.Map<Domain.Entity.HR.Contact>(contact);
            contactEntity.CountryID = countriesDic[contact.Key!];
            var existingContact = await unitofWork.ContactRepo.GetByIdAsync(contactEntity.Id );

            mapper.Map(contactEntity, existingContact);
        }
        // Save changes to the database
        await unitofWork.SaveChangesAsync(cancellationToken);
        var ids = request.Contacts.Select(c => c.Id).ToList();
        var returendContact = await unitofWork.ContactRepo.FindMultiRowsBy(x => ids.Contains(x.Id), x => x.Country, x => x.Person);
        return mapper.Map<List<RequestContactDto>>(returendContact);

    }
}
