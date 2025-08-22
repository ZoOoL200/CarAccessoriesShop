using CarAccessoriesShop.Application.DTOs.Category.CommandDtos;
using FluentValidation;

namespace CarAccessoriesShop.Application.DTOs.Category.Validators;

internal class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDto>
{
    public UpdateCategoryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("Id is required.")
            .NotEmpty().WithMessage("Id is required.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(30).WithMessage("Title must not exceed 30 characters.");

        RuleFor(x => x.Description)
            .MaximumLength(200).WithMessage("Description must not exceed 200 characters.")
            .When(x => !string.IsNullOrWhiteSpace(x.Description));
    }
}

