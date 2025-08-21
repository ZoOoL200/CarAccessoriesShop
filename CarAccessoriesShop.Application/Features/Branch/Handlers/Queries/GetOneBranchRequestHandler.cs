using AutoMapper;
using CarAccessoriesShop.Application.DTOs.Branch.QueryDtos;
using CarAccessoriesShop.Application.Exceptions;
using CarAccessoriesShop.Application.Features.Branch.Requests.Queries;
using CarAccessoriesShop.Application.Presistences.UnitofWork;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Branch.Handlers.Queries;

internal class GetOneBranchRequestHandler(IUnitofWork unitofWork, IMapper mapper) : IRequestHandler<GetOneBranchRequest, BranchDto>
{
    public async Task<BranchDto> Handle(GetOneBranchRequest request, CancellationToken cancellationToken)
    {
        var branch = await unitofWork.BranchRepo.GetByIdAsync(request.Id)
            ?? throw new NotFoundException($"Branch with ID {request.Id} not found.");
        // Map the Branch entity to BranchDto
        return mapper.Map<BranchDto>(branch);
    }
}
