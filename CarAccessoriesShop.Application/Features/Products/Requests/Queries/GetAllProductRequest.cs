using CarAccessoriesShop.Application.DTOs.Product.QueryDtos;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Products.Requests.Queries;

public class GetAllProductRequest : IRequest<IEnumerable<ProductDto>>
{
}
