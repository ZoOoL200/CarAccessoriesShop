using CarAccessoriesShop.Application.DTOs.Branch.CommandDtos;
using CarAccessoriesShop.Application.DTOs.Branch.QueryDtos;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Branch.Requests.Commands;

public class InsertBranchRequest (InsertBranchDto branch) : IRequest<BranchDto>
{
    public InsertBranchDto Branch { get; set; } = branch;
}
