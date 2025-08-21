using CarAccessoriesShop.Application.DTOs.Branch.CommandDtos;
using FluentValidation;

namespace CarAccessoriesShop.Application.DTOs.Branch.Validators;

internal class InsertBranchDtoValidator : AbstractValidator<InsertBranchDto>
{
    public InsertBranchDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Branch title is required.")
            .MaximumLength(30)
            .WithMessage("Branch title must not exceed 30 characters.");
        RuleFor(x => x.Location)
            .MaximumLength(100)
            .WithMessage("Branch location must not exceed 100 characters.");
    }
}
