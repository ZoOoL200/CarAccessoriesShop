using AutoMapper;
using CarAccessoriesShop.Application.DTOs.Branch.QueryDtos;
using CarAccessoriesShop.Application.Exceptions;
using CarAccessoriesShop.Application.Features.Branch.Requests.Commands;
using CarAccessoriesShop.Application.Presistences.UnitofWork;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Branch.Handlers.Commands;

internal class UpdateBranchRequestHandler(IUnitofWork unitofWork, IMapper mapper) : IRequestHandler<UpdateBranchRequest, BranchDto>
{
    public async Task<BranchDto> Handle(UpdateBranchRequest request, CancellationToken cancellationToken)
    {
        var branch = await unitofWork.BranchRepo.GetByIdAsync(request.Branch.Id)
            ?? throw new NotFoundException($"Branch with ID {request.Branch.Id} not found.");
        // Map the UpdateBranchDto to the Branch entity
        mapper.Map(request.Branch, branch);
        // Update the branch in the repository
        await unitofWork.SaveChangesAsync(cancellationToken);
        return mapper.Map<BranchDto>(branch);
    }
}
