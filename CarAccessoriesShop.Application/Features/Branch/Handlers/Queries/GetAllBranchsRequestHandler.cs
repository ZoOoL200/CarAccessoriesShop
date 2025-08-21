using AutoMapper;
using CarAccessoriesShop.Application.DTOs.Branch.QueryDtos;
using CarAccessoriesShop.Application.Features.Branch.Requests.Queries;
using CarAccessoriesShop.Application.Presistences.UnitofWork;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Branch.Handlers.Queries;

internal class GetAllBranchsRequestHandler(IUnitofWork unitofWork, IMapper mapper) : IRequestHandler<GetAllBranchsRequest, IEnumerable<BranchDto>>
{
    public async Task<IEnumerable<BranchDto>> Handle(GetAllBranchsRequest request, CancellationToken cancellationToken)
    {
        // Retrieve all branches from the repository
        var branches = await unitofWork.BranchRepo.GetAllAsync(x=>x.Id);
        // Map the Branch entities to BranchDto
        if (branches != null)
        {
            return mapper.Map<IEnumerable<BranchDto>>(branches);
        }
        // If no branches are found, return an empty list
        return [];
    }
}

