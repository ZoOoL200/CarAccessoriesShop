using CarAccessoriesShop.Application.DTOs.Category.CommandDtos;
using CarAccessoriesShop.Application.DTOs.Category.QueryDtos;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Categories.Requests.Commands;

public class UpdateCategoryRequest(UpdateCategoryDto categoryDto) : IRequest<CategoryDto>
{
    public UpdateCategoryDto Category { get; } = categoryDto;
}
