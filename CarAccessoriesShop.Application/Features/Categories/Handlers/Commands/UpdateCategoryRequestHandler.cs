using AutoMapper;
using CarAccessoriesShop.Application.DTOs.Category.QueryDtos;
using CarAccessoriesShop.Application.Exceptions;
using CarAccessoriesShop.Application.Features.Categories.Requests.Commands;
using CarAccessoriesShop.Application.Presistences.UnitofWork;
using CarAccessoriesShop.Domain.Entity.Main;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Categories.Handlers.Commands;

internal class UpdateCategoryRequestHandler(IUnitofWork unitofWork, IMapper mapper) : IRequestHandler<UpdateCategoryRequest, CategoryDto>
{
    public async Task<CategoryDto> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        // get the category by id
        var category = await unitofWork.CategoryRepo.GetByIdAsync(request.Category.Id)
            ?? throw new NotFoundException(nameof(Category), request.Category.Id);
        // update the category
        mapper.Map(request.Category, category);
        // save changes
        await unitofWork.SaveChangesAsync(cancellationToken);
        // return the updated category
        return mapper.Map<CategoryDto>(category);
    }
}

