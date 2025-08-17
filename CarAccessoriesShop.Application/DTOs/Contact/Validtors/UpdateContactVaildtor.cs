using CarAccessoriesShop.Application.Exceptions;
using CarAccessoriesShop.Application.Presistences.UnitofWork;
using FluentValidation;

namespace CarAccessoriesShop.Application.DTOs.Contact.Validtors;

internal class UpdateContactVaildtor : AbstractValidator<UpdateContactDto>
{
    private readonly IUnitofWork unitofWork;
    public UpdateContactVaildtor(IUnitofWork _unitofWork)
    {
        unitofWork = _unitofWork;
        // Validate the ID
        RuleFor(c => c.Id)
           .NotEmpty().WithMessage("Contact ID is required.")
           .MustAsync(async (id, token) =>
           {
               return await unitofWork.ContactRepo.IsExistsAsync(id);
           }).WithMessage("Contact with the specified ID does not exist.");

        // Validate the Telephone
        RuleFor(c => c.Telephone)
            .NotEmpty().WithMessage("Telephone Number is required.")
            .Matches(@"^[0-9\-]+$").WithMessage("{PropertyName} must be just numbers.")
            .MaximumLength(15);

        // Validate the Key
        RuleFor(c => c.Key)
            .NotEmpty().WithMessage(" {PropertyName} is required.")
            .MaximumLength(8)
            .MustAsync(async (Key, token) =>
            {
                 return await unitofWork.CountryKeyRepo.IsExistsAsync(x => x.Key == Key);
            }).WithMessage("{PropertyName} Is not Exists");

    }
}
