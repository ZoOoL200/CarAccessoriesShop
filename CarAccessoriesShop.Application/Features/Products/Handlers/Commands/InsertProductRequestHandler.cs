using AutoMapper;
using CarAccessoriesShop.Application.DTOs.Product.QueryDtos;
using CarAccessoriesShop.Application.Features.Products.Requests.Commands;
using CarAccessoriesShop.Application.Presistences.UnitofWork;
using CarAccessoriesShop.Domain.Entity.Main;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Products.Handlers.Commands;

internal class InsertProductRequestHandler(IUnitofWork unitofWork, IMapper mapper) : IRequestHandler<InsertProductRequest, ProductDto>
{
    public async Task<ProductDto> Handle(InsertProductRequest request, CancellationToken cancellationToken)
    {
        // map InsertProductDto to Product entity
        var product = mapper.Map<Product>(request.Product);
        // add the product to the repository
        await unitofWork.ProductRepo.AddAsync(product);
        await unitofWork.SaveChangesAsync(cancellationToken);
        // map the Product entity back to ProductDto
        var returnedProduct = await unitofWork.ProductRepo.FindRowBy(x=> x.Id == product.Id, x=>x.Category);
        return mapper.Map<ProductDto>(product);
    }
}

