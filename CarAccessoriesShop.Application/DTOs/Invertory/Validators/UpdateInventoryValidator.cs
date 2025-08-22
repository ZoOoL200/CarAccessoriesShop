using CarAccessoriesShop.Application.DTOs.Invertory.CommandDtos;
using CarAccessoriesShop.Application.Presistences.UnitofWork;
using FluentValidation;

namespace CarAccessoriesShop.Application.DTOs.Invertory.Validators;

internal class UpdateInventoryValidator : AbstractValidator<UpdateInventoryDto>
{
    private readonly IUnitofWork unitofWork;
    public UpdateInventoryValidator(IUnitofWork _unitofWork)
    {
        unitofWork = _unitofWork;
        RuleFor(x => x.Id)
            .NotNull().WithMessage("Id is required.")
            .NotEmpty().WithMessage("Id is required.")
            .MustAsync(async (id, token) =>
            {
                return await unitofWork.InventoryRepo.IsExistsAsync(x => x.Id == id);
            }).WithMessage("This Id  is not exists");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");

        RuleFor(x => x.BranchID)
            .NotNull().WithMessage("BranchID is required.")
            .NotEmpty().WithMessage("BranchID is required.")
            .MustAsync(async (id, token) =>
            {
                return await unitofWork.BranchRepo.IsExistsAsync(x => x.Id == id);
            }).WithMessage("This BranchID  is not exists"); 
    }
}
