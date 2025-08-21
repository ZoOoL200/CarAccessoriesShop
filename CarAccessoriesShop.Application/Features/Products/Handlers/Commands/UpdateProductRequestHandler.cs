using AutoMapper;
using CarAccessoriesShop.Application.DTOs.Product.QueryDtos;
using CarAccessoriesShop.Application.Exceptions;
using CarAccessoriesShop.Application.Features.Products.Requests.Commands;
using CarAccessoriesShop.Application.Presistences.UnitofWork;
using CarAccessoriesShop.Domain.Entity.Main;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Products.Handlers.Commands;

internal class UpdateProductRequestHandler(IUnitofWork unitofWork, IMapper mapper) : IRequestHandler<UpdateProductRequest, ProductDto>
{
    public async Task<ProductDto> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {

        // get the existing product from the database
        var exisitProduct  = await unitofWork.ProductRepo.GetByIdAsync(request.Product.Id) 
            ?? throw new NotFoundException($"Product with ID {request.Product.Id} not found.");
        // check if the category exists and update the category ID if it has changed
        if (exisitProduct.CategoryID != request.Product.CategoryID)
        {
            var category = await unitofWork.CategoryRepo.GetByIdAsync(request.Product.CategoryID) 
                ?? throw new NotFoundException($"Category with ID {request.Product.CategoryID} not found.");
            exisitProduct.CategoryID = category.Id;
        }
        // map the updated product details to the existing product
        mapper.Map(request.Product, exisitProduct);
        await unitofWork.SaveChangesAsync(cancellationToken);
        // return the updated product as a ProductDto
        var returnedProduct = await unitofWork.ProductRepo.FindRowBy(x => x.Id == exisitProduct.Id, x => x.Category);
        return mapper.Map<ProductDto>(exisitProduct);
    }
}
