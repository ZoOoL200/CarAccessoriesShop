using CarAccessoriesShop.Application.DTOs.Product.CommandDtos;
using CarAccessoriesShop.Application.Presistences.UnitofWork;
using FluentValidation;

namespace CarAccessoriesShop.Application.DTOs.Product.Validators;

internal class InsertProductValidator : AbstractValidator<InsertProductDto>
{
    private readonly IUnitofWork unitofWork;
    public InsertProductValidator(IUnitofWork _unitofWork)
    {
        unitofWork = _unitofWork;

        RuleFor(p => p.Title)
            .NotEmpty()
            .WithMessage("Title is required.")
            .MaximumLength(50)
            .WithMessage("Title must not exceed 50 characters.");
        RuleFor(p => p.Description)
            .MaximumLength(200)
            .WithMessage("Description must not exceed 200 characters.");
        RuleFor(p => p.CategoryID)
            .NotEmpty().WithMessage("Category ID is required.")
            .MustAsync(async (categoryId, cancellation) =>
            {
                return await unitofWork.CategoryRepo.IsExistsAsync(categoryId);
            }).WithMessage("The Category does not exist.");
    }
}
