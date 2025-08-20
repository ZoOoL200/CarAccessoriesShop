using AutoMapper;
using CarAccessoriesShop.Application.DTOs.Supplier.Query;
using CarAccessoriesShop.Application.Features.Supplier.Requests.Commands;
using CarAccessoriesShop.Application.Presistences.UnitofWork;
using CarAccessoriesShop.Domain.Entity.HR;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Supplier.Handlers.Commands;

internal class CreateSupplierRequestHandler(IUnitofWork unitofWork, IMapper mapper) : IRequestHandler<CreateSupplierRequest, SupplierDto>
{
    public async Task<SupplierDto> Handle(CreateSupplierRequest request, CancellationToken cancellationToken)
    {
        await unitofWork.BeginTransactionAsync(cancellationToken);
        try
        {
            // Create a new Person entity for the supplier
            var PersonContact = new Person
            {
                ReferenceType = "Supplier",
                PersonName = request.Supplier.SupplierName
            };
            await unitofWork.PersonRepo.AddAsync(PersonContact);
            await unitofWork.SaveChangesAsync(cancellationToken);

            // Create a new Supplier entity and map the request data to it
            var supplire = mapper.Map<CarAccessoriesShop.Domain.Entity.HR.Supplier>(request.Supplier);
            supplire.PersonContactID = PersonContact.Id;
            await unitofWork.SupplierRepo.AddAsync(supplire);
            await unitofWork.SaveChangesAsync(cancellationToken);
            var supplierDto = mapper.Map<SupplierDto>(supplire);

            // Commit the transaction
            await unitofWork.CommitTransactionAsync(cancellationToken);
            return supplierDto;
        }
        catch (Exception)
        {
            await unitofWork.RollbackTransactionAsync(cancellationToken);
            throw ;
        }
    }
}
