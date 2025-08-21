using AutoMapper;
using CarAccessoriesShop.Application.DTOs.Product.QueryDtos;
using CarAccessoriesShop.Application.Exceptions;
using CarAccessoriesShop.Application.Features.Products.Requests.Queries;
using CarAccessoriesShop.Application.Presistences.UnitofWork;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Products.Handlers.Queries;

internal class GetProductsByCategoryRequestHandler(IUnitofWork unitofWork, IMapper mapper) : IRequestHandler<GetProductsByCategoryRequest, IList<ProductDto>>
{
    public async Task<IList<ProductDto>> Handle(GetProductsByCategoryRequest request, CancellationToken cancellationToken)
    {
        // check if the category exists
        if(!await unitofWork.CategoryRepo.IsExistsAsync(request.CategoryId))
        {
            throw new NotFoundException($"Category with ID {request.CategoryId} does not exist.");
        }
        // get products by category
        var ProductCategory = await unitofWork.ProductRepo.FindMultiRowsBy(x => x.CategoryID == request.CategoryId, x => x.Category);
        // check if products exist in the category returned else return empty list
        if (ProductCategory != null)
        {
            return mapper.Map<IList<ProductDto>>(ProductCategory);
        }
        else
        {
            return [];
        }
       
    }
}

