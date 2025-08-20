using CarAccessoriesShop.Application.DTOs.Contact.CommandDtos;
using CarAccessoriesShop.Application.Exceptions;
using CarAccessoriesShop.Application.Presistences.UnitofWork;
using FluentValidation;

namespace CarAccessoriesShop.Application.DTOs.Contact.Validtors;

internal class CreatContactValidtor: AbstractValidator<CreatContactDto>
{
    private readonly IUnitofWork unitofWork;
    public CreatContactValidtor(IUnitofWork _unitofWork)
    {
        unitofWork = _unitofWork;

        // Validate the Telephone
        RuleFor(c => c.Telephone)
            .NotEmpty().WithMessage("Telephone Number is required.")
            .Matches(@"^[0-9\-]+$").WithMessage("{PropertyName} must be just numbers.")
            .MaximumLength(15);

        // Validate the Key
        RuleFor(c => c.Key)
            .NotEmpty().WithMessage(" {PropertyName} is required.")
            .MaximumLength(8)
            .MustAsync(async(Key, token) => 
            {
                try 
                {
                    return await unitofWork.CountryKeyRepo.IsExistsAsync(x => x.Key == Key);
                }
                catch (Exception ex)
                {
                    throw new InternalServerErrorException("An error occurred while checking the key existence.", ex);
                }

            }).WithMessage("{PropertyName} Is not Exists");

        // Validate the PersonID
        RuleFor(c => c.PersonID)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MustAsync(async (id, token) =>
            {
                return await unitofWork.PersonRepo.IsExistsAsync(id);

            }).WithMessage("{PropertyName} is not exists");
    }
}
