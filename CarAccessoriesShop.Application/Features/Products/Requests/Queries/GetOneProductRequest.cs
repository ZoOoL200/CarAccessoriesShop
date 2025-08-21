using CarAccessoriesShop.Application.DTOs.Product.QueryDtos;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Products.Requests.Queries;

public class GetOneProductRequest(Guid Id) : IRequest<ProductDto>
{
    public Guid Id { get; set; } = Id;
}
