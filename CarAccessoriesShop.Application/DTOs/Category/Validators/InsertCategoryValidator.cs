using CarAccessoriesShop.Application.DTOs.Category.CommandDtos;
using FluentValidation;

namespace CarAccessoriesShop.Application.DTOs.Category.Validators;

internal class InsertCategoryValidator : AbstractValidator<InsertCategoryDto>
{
    public InsertCategoryValidator()
    {
        RuleFor(x => x.Title)
            .NotNull().WithMessage("Title is required.")
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(30).WithMessage("Title must not exceed 30 characters.");

        RuleFor(x => x.Description)
            .MaximumLength(200).WithMessage("Description must not exceed 200 characters.")
            .When(x => !string.IsNullOrWhiteSpace(x.Description));
    }
}
