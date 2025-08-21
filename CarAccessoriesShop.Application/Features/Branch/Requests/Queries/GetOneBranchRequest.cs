using CarAccessoriesShop.Application.DTOs.Branch.QueryDtos;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Branch.Requests.Queries;

public class GetOneBranchRequest(Guid Id) : IRequest<BranchDto>
{
    public Guid Id { get; set; } = Id;
}
