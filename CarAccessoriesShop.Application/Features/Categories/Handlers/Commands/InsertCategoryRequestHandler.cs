using AutoMapper;
using CarAccessoriesShop.Application.DTOs.Category.QueryDtos;
using CarAccessoriesShop.Application.Features.Categories.Requests.Commands;
using CarAccessoriesShop.Application.Presistences.UnitofWork;
using CarAccessoriesShop.Domain.Entity.Main;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Categories.Handlers.Commands;

internal class InsertCategoryRequestHandler(IUnitofWork unitofWork, IMapper mapper) : IRequestHandler<InsertCategoryRequest, CategoryDto>
{
    public async Task<CategoryDto> Handle(InsertCategoryRequest request, CancellationToken cancellationToken)
    {
        // Map request to Category entity
        var category = mapper.Map<Category>(request.Category);
        // Add Category to Database
        await unitofWork.CategoryRepo.AddAsync(category);
        await unitofWork.SaveChangesAsync(cancellationToken);
        // return CategoryDto
        return mapper.Map<CategoryDto>(category);
    }
}
