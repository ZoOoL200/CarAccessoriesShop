using CarAccessoriesShop.Application.DTOs.Supplier.CommandDtos;
using FluentValidation;

namespace CarAccessoriesShop.Application.DTOs.Supplier.Validtors;

internal class InsertSupplierValidtor : AbstractValidator<InsertSupplierDto>
{
    public InsertSupplierValidtor()
    {
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
