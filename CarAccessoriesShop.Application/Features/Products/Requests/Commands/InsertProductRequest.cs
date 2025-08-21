using CarAccessoriesShop.Application.DTOs.Product.CommandDtos;
using CarAccessoriesShop.Application.DTOs.Product.QueryDtos;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Products.Requests.Commands;

public class InsertProductRequest(InsertProductDto product) : IRequest<ProductDto>
{
    public InsertProductDto Product { get; set; } = product ;
}
