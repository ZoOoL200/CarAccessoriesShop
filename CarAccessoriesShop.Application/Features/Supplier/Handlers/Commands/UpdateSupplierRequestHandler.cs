using AutoMapper;
using CarAccessoriesShop.Application.DTOs.Supplier.Query;
using CarAccessoriesShop.Application.Features.Supplier.Requests.Commands;
using CarAccessoriesShop.Application.Presistences.UnitofWork;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Supplier.Handlers.Commands
{
    internal class UpdateSupplierRequestHandler(IUnitofWork unitofWork, IMapper mapper) : IRequestHandler<UpdateSupplierRequest, SupplierDto>
    {
        public async Task<SupplierDto> Handle(UpdateSupplierRequest request, CancellationToken cancellationToken)
        {
            await unitofWork.BeginTransactionAsync(cancellationToken);
            try 
            {
                var existingSupplier = await unitofWork.SupplierRepo.GetByIdAsync(request.Supplier.Id);
                if( request.Supplier.SupplierName != existingSupplier!.SupplierName)
                {
                    // Update the Person entity if the SupplierName has changed
                    var person = await unitofWork.PersonRepo.GetByIdAsync(existingSupplier.PersonContactID)
                        ?? throw new KeyNotFoundException($"Person Contact with ID {existingSupplier.PersonContactID} not found.");
                    person.PersonName = request.Supplier.SupplierName;
                }
                // Update the Supplier entity
                mapper.Map(request.Supplier, existingSupplier);
                await unitofWork.SaveChangesAsync(cancellationToken);
                // Commit the transaction
                await unitofWork.CommitTransactionAsync(cancellationToken);
                return mapper.Map<SupplierDto>(existingSupplier);
            }
            catch (Exception)
            {
                await unitofWork.RollbackTransactionAsync(cancellationToken);
                throw;
            }
        }
    }
}
