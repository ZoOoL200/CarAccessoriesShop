using CarAccessoriesShop.Application.DTOs.Product.CommandDtos;
using CarAccessoriesShop.Application.DTOs.Product.QueryDtos;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Products.Requests.Commands;

public class UpdateProductRequest(UpdateProductDto product) : IRequest<ProductDto>
{
    public UpdateProductDto Product { get; set; } = product;
}
