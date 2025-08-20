using AutoMapper;
using CarAccessoriesShop.Application.DTOs.Contact.QueryDtos;
using CarAccessoriesShop.Application.DTOs.Supplier.Query;
using CarAccessoriesShop.Application.Features.Supplier.Requests.Queries;
using CarAccessoriesShop.Application.Presistences.UnitofWork;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Supplier.Handlers.Queries
{
    internal class GetAllSupplierRequestHandler(IUnitofWork unitofWork, IMapper mapper) : IRequestHandler<GetAllSupplierRequest, IEnumerable<SupplierWithContactDto>>
    {
        public async Task<IEnumerable<SupplierWithContactDto>> Handle(GetAllSupplierRequest request, CancellationToken cancellationToken)
        {
            // Get Suppliers for DataBase
            var Suppliers = await unitofWork.SupplierRepo.GetAllAsync(x=>x.Id);
            if (Suppliers != null)
            {
                // Get Contacts for DataBase
                var PersonsContactIds = Suppliers.Select(x => x.PersonContactID).ToList();
                var Contacts = await unitofWork.ContactRepo.FindMultiRowsBy(x => PersonsContactIds.Contains(x.PersonID), x => x.Country);
                var contactsGrouped = Contacts.GroupBy(c => c.PersonID).ToDictionary(g => g.Key, g => g.ToList());
                // Map the suppliers to DTOs
                var returnedDto = mapper.Map<IEnumerable<SupplierWithContactDto>>(Suppliers);
                foreach (var supplier in returnedDto)
                {
                    // Map the contacts to the supplier
                    if (contactsGrouped.TryGetValue(supplier.PersonContactID, out var supplierContacts))
                    {
                        supplier.PersonContacts = mapper.Map<IList<ShowPersonContactDto>>(supplierContacts);
                    }
                    else
                    {
                        supplier.PersonContacts = [];
                    }
                }
                // Return the mapped DTOs
                return returnedDto;
            }
            // Return an empty list if no suppliers found
            return [];
        }
    }
}
