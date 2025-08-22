using AutoMapper;
using CarAccessoriesShop.Application.DTOs.Category.QueryDtos;
using CarAccessoriesShop.Application.Features.Categories.Requests.Queries;
using CarAccessoriesShop.Application.Presistences.UnitofWork;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Categories.Handlers.Queries;

internal class GetAllCategoryRequestHandler(IUnitofWork unitofWork, IMapper mapper) : IRequestHandler<GetAllCategoryRequest, List<CategoryDto>>
{
    public async Task<List<CategoryDto>> Handle(GetAllCategoryRequest request, CancellationToken cancellationToken)
    {
        var categories = await unitofWork.CategoryRepo.GetAllAsync(x=>x.Id);
        return mapper.Map<List<CategoryDto>>(categories);
    }
}
