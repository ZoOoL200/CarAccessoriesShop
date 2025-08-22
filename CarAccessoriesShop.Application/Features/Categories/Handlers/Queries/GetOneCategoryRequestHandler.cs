using AutoMapper;
using CarAccessoriesShop.Application.DTOs.Category.QueryDtos;
using CarAccessoriesShop.Application.Exceptions;
using CarAccessoriesShop.Application.Features.Categories.Requests.Queries;
using CarAccessoriesShop.Application.Presistences.UnitofWork;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Categories.Handlers.Queries;

internal class GetOneCategoryRequestHandler(IUnitofWork unitofWork, IMapper mapper) : IRequestHandler<GetOneCategoryRequest, CategoryDto>
{
    public async Task<CategoryDto> Handle(GetOneCategoryRequest request, CancellationToken cancellationToken)
    {
        // Get Category by Id
        var category = await unitofWork.CategoryRepo.GetByIdAsync(request.Id)
            ?? throw new NotFoundException($"Category with Id {request.Id} not found.");
        // Map Category to CategoryDto
        return mapper.Map<CategoryDto>(category);
    }
}
