using CarAccessoriesShop.Application.DTOs.Category.QueryDtos;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Categories.Requests.Queries;

public class GetAllCategoryRequest : IRequest<List<CategoryDto>>
{
}
