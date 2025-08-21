using CarAccessoriesShop.Application.DTOs.Product.QueryDtos;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Products.Requests.Queries;

public class GetProductsByCategoryRequest(short categoryId) : IRequest<IList<ProductDto>>
{
    public short CategoryId { get; set; } = categoryId;
}
