using CarAccessoriesShop.Application.DTOs.Category.CommandDtos;
using CarAccessoriesShop.Application.DTOs.Category.QueryDtos;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Categories.Requests.Commands;

public class InsertCategoryRequest(InsertCategoryDto categoryDto) : IRequest<CategoryDto>
{
    public InsertCategoryDto Category = categoryDto;
}
