using CarAccessoriesShop.Application.DTOs.Category.QueryDtos;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Categories.Requests.Queries;

public class GetOneCategoryRequest(Guid Id) : IRequest<CategoryDto>
{
    public Guid Id { get; set; } = Id;
}
