using AutoMapper;
using CarAccessoriesShop.Application.DTOs.Contact;
using CarAccessoriesShop.Application.Features.Contact.Requests.Commands;
using CarAccessoriesShop.Application.Presistences.UnitofWork;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Contact.Handlers.Commands;
/// <summary>
/// Handles the insertion of a new contact into the system.
/// </summary>
/// <remarks>This handler processes an <see cref="InsertContactRequest"/> to add a new contact to the database. It
/// maps the incoming request data to a domain entity, persists the entity using the provided unit of work, and returns
/// a DTO representing the newly created contact.</remarks>
/// <param name="unitofWork">The unit of work used to manage database operations. Cannot be null.</param>
/// <param name="mapper">The mapper used to convert between request, domain, and DTO objects. Cannot be null.</param>
public class InsertContactRequestHandler(IUnitofWork unitofWork, IMapper mapper) : IRequestHandler<InsertContactRequest, RequestContactDto>
{
    public async Task<RequestContactDto> Handle(InsertContactRequest request, CancellationToken cancellationToken)
    {

        // Map the request data to a domain entity
        var contactEntity = mapper.Map<CarAccessoriesShop.Domain.Entity.HR.Contact>(request.Contact);

        // Attempt to retrieve the country by key and set the CountryID
        var country = await unitofWork.CountryKeyRepo.FindRowBy(x => x.Key == request.Contact.Key);
        contactEntity.CountryID = country.Id;
        // Ateemp to add the contact entity to the repository
        await unitofWork.ContactRepo.AddAsync(contactEntity);
        // Save changes to the database
        await unitofWork.SaveChangesAsync(cancellationToken);
        // Retrieve the newly created contact entity with related data
        var returnedContact = await unitofWork.ContactRepo.FindRowBy(X=>X.Id == contactEntity.Id , x=>x.Country, x=>x.Person);
        return mapper.Map<RequestContactDto>(returnedContact);

    }
}
/// <summary>
/// Handles the insertion of a list of contacts into the data store and returns the inserted contacts as DTOs.
/// </summary>
/// <remarks>This handler processes an <see cref="InsertListContactRequest"/> by mapping the provided contact data
/// to  domain entities, saving them to the repository, and then mapping the saved entities back to DTOs for the
/// response.</remarks>
/// <param name="unitofWork"></param>
/// <param name="mapper"></param>
public class InsertListContactRequestHandler(IUnitofWork unitofWork, IMapper mapper) : IRequestHandler<InsertListContactRequest, List<RequestContactDto>>
{

    public async Task<List<RequestContactDto>> Handle(InsertListContactRequest request, CancellationToken cancellationToken)
    {
        // Create a list to hold the contact entities
        var contactentities = new List<CarAccessoriesShop.Domain.Entity.HR.Contact>();

        // Get all Keys from the request contacts
        var keys = request.Contacts.Select(x => x.Key).Distinct().ToList();

        // Gert dictionary of countries based on the keys
        var countries = await unitofWork.CountryKeyRepo.FindMultiRowsBy(c => keys.Contains(c.Key));
        var countriesDic = countries.ToDictionary(c => c.Key, c => c.Id);

        // Assign the CountryID to each contact entity based on the provided keys
        foreach (var contact in request.Contacts)
        {
            var contactEntity = mapper.Map<CarAccessoriesShop.Domain.Entity.HR.Contact>(contact);
            contactEntity.CountryID = countriesDic[contact.Key!];
            contactentities.Add(contactEntity);
        }
        // Add the contact entities to the repository and save changes
        await unitofWork.ContactRepo.AddAsync(contactentities);
        await unitofWork.SaveChangesAsync(cancellationToken);
        // Retrieve the saved contacts with related data and map them to DTOs
        var ids = contactentities.Select(c => c.Id).ToList();
        var returendContact = await unitofWork.ContactRepo.FindMultiRowsBy(x =>  ids.Contains(x.Id), x => x.Country, x => x.Person);
        return mapper.Map<List<RequestContactDto>>(returendContact);
        
    }
}
