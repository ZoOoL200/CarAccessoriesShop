using CarAccessoriesShop.Application.DTOs.Invertory.CommandDtos;
using CarAccessoriesShop.Application.Presistences.UnitofWork;
using FluentValidation;

namespace CarAccessoriesShop.Application.DTOs.Invertory.Validators;

internal class InsertInventoryValidator : AbstractValidator<InsertInvetoryDto>
{
    private readonly IUnitofWork unitofWork;
    public InsertInventoryValidator(IUnitofWork _unitofWork)
    {
        unitofWork = _unitofWork;
        RuleFor(x => x.Title)
            .NotNull().WithMessage("Title is required.")
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");

        RuleFor(x => x.BranchID)
            .NotNull().WithMessage("BranchID is required.")
            .NotEmpty().WithMessage("BranchID is required.")
            .MustAsync(async(id, token)=> 
            {
                return await unitofWork.BranchRepo.IsExistsAsync(x=> x.Id== id);
            }).WithMessage("This BranchID  is not exists");
    }
}
