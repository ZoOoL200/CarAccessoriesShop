using AutoMapper;
using CarAccessoriesShop.Application.DTOs.Product.QueryDtos;
using CarAccessoriesShop.Application.Exceptions;
using CarAccessoriesShop.Application.Features.Products.Requests.Queries;
using CarAccessoriesShop.Application.Presistences.UnitofWork;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Products.Handlers.Queries;

internal class GetOneProductRequestHandler(IUnitofWork unitofWork, IMapper mapper) : IRequestHandler<GetOneProductRequest, ProductDto>
{
    public async Task<ProductDto> Handle(GetOneProductRequest request, CancellationToken cancellationToken)
    {
        // get product by id
        var product = await unitofWork.ProductRepo.FindRowBy(x=> x.Id== request.Id , x=>x.Category)
            ?? throw new NotFoundException($"Product with ID {request.Id} not found.");
        // map to ProductDto
        return mapper.Map<ProductDto>(product);
    }
}
