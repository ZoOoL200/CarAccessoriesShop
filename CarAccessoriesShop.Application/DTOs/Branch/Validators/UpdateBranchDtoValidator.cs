using CarAccessoriesShop.Application.DTOs.Branch.CommandDtos;
using FluentValidation;

namespace CarAccessoriesShop.Application.DTOs.Branch.Validators
{
    internal class UpdateBranchDtoValidator : AbstractValidator<UpdateBranchDto>
    {
        public UpdateBranchDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Branch ID is required.")
                .NotNull()
                .WithMessage("Branch ID is required.");
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
}
