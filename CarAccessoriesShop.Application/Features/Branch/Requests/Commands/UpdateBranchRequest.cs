using CarAccessoriesShop.Application.DTOs.Branch.CommandDtos;
using CarAccessoriesShop.Application.DTOs.Branch.QueryDtos;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Branch.Requests.Commands;

public class UpdateBranchRequest (UpdateBranchDto branch) : IRequest<BranchDto>
{
    public UpdateBranchDto Branch { get; set; } = branch;
}
