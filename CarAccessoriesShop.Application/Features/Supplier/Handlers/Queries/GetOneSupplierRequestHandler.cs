using AutoMapper;
using CarAccessoriesShop.Application.DTOs.Contact.QueryDtos;
using CarAccessoriesShop.Application.DTOs.Supplier.Query;
using CarAccessoriesShop.Application.Exceptions;
using CarAccessoriesShop.Application.Features.Supplier.Requests.Queries;
using CarAccessoriesShop.Application.Presistences.UnitofWork;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Supplier.Handlers.Queries
{
    internal class GetOneSupplierRequestHandler(IUnitofWork unitofWork, IMapper mapper) : IRequestHandler<GetOneSupplierRequest, SupplierWithContactDto>
    {
        public async Task<SupplierWithContactDto> Handle(GetOneSupplierRequest request, CancellationToken cancellationToken)
        {
            // get the supplier by id
            var supplier = await unitofWork.SupplierRepo.GetByIdAsync(request.Id);
            if (supplier == null)
            {
                throw new NotFoundException($"Supplier with ID {request.Id} not found.");
            }
            // map the supplier to the DTO
            var supplierDto = mapper.Map<SupplierWithContactDto>(supplier);
            // get the person contacts by person id
            var contacts = await unitofWork.ContactRepo.FindMultiRowsBy(c => c.PersonID == supplier.PersonContactID);
            // if contacts are found, map them to the DTO, otherwise set it to an empty list    
            if (contacts != null )
            {
                supplierDto.PersonContacts = mapper.Map<List<ShowPersonContactDto>>(contacts);
            }
            else
            {
                supplierDto.PersonContacts = [];
            }
            // return the supplier DTO
            return supplierDto;
        }
    }
}
