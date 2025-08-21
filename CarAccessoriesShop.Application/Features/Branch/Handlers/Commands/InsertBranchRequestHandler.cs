using AutoMapper;
using CarAccessoriesShop.Application.DTOs.Branch.QueryDtos;
using CarAccessoriesShop.Application.Features.Branch.Requests.Commands;
using CarAccessoriesShop.Application.Presistences.UnitofWork;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Branch.Handlers.Commands;

internal class InsertBranchRequestHandler(IUnitofWork unitofWork, IMapper mapper) : IRequestHandler<InsertBranchRequest, BranchDto>
{
    async Task<BranchDto> IRequestHandler<InsertBranchRequest, BranchDto>.Handle(InsertBranchRequest request, CancellationToken cancellationToken)
    {
        // Map the InsertBranchDto to the Branch entity
        var branch = mapper.Map<CarAccessoriesShop.Domain.Entity.Main.Branch>(request.Branch);
        // add the branch to the repository
        await unitofWork.BranchRepo.AddAsync(branch);
        // Save changes to the database
        await unitofWork.SaveChangesAsync(cancellationToken);
        // Map the Branch entity back to BranchDto for the response
        return mapper.Map<BranchDto>(branch);
    }
}
