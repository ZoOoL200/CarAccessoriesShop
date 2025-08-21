using CarAccessoriesShop.Application.DTOs.Product.CommandDtos;
using CarAccessoriesShop.Application.Presistences.UnitofWork;
using FluentValidation;

namespace CarAccessoriesShop.Application.DTOs.Product.Validators;

internal class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
{
    private readonly IUnitofWork unitofWork;
    public UpdateProductDtoValidator(IUnitofWork _unitofWork)
    {
        unitofWork = _unitofWork;
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("Product ID is required.")
            .NotEqual(Guid.Empty).WithMessage("Product ID cannot be empty.");
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
