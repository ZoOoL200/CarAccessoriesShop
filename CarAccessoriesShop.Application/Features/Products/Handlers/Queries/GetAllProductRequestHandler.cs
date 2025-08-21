using AutoMapper;
using CarAccessoriesShop.Application.DTOs.Product.QueryDtos;
using CarAccessoriesShop.Application.Features.Products.Requests.Queries;
using CarAccessoriesShop.Application.Presistences.UnitofWork;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Products.Handlers.Queries;

internal class GetAllProductRequestHandler(IUnitofWork unitofWork, IMapper mapper): IRequestHandler<GetAllProductRequest, IEnumerable<ProductDto>>
{
    public async Task<IEnumerable<ProductDto>> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
    {
        // Fetch all products along with their categories from the repository
        var products = await unitofWork.ProductRepo.GetAllAsync(x=>x.Id, x=>x.Category);
        return mapper.Map<IEnumerable<ProductDto>>(products);
    }
}

