using CarAccessoriesShop.Application.DTOs.Supplier.CommandDtos;
using CarAccessoriesShop.Application.Presistences.UnitofWork;
using FluentValidation;

namespace CarAccessoriesShop.Application.DTOs.Supplier.Validtors;

internal class UpdateSupplierVaidtor : AbstractValidator<UpdateSupplierDto>
{
    public UpdateSupplierVaidtor(IUnitofWork unitofWork)
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.")
            .MustAsync(async(id,token)=>
            {
                return await unitofWork.SupplierRepo.IsExistsAsync(id);
            }).WithMessage("Identifier isn't Exsits.");
        RuleFor(x => x.SupplierName)
            .NotEmpty()
            .WithMessage("Supplier name is required.")
            .MaximumLength(50)
            .WithMessage("Supplier name must not exceed 50 characters.");
        RuleFor(x => x.Address)
            .MaximumLength(250)
            .WithMessage("Address must not exceed 250 characters.");
    }
}
