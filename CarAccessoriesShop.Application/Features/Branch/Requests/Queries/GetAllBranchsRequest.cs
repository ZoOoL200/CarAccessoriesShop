using CarAccessoriesShop.Application.DTOs.Branch.QueryDtos;
using MediatR;

namespace CarAccessoriesShop.Application.Features.Branch.Requests.Queries;

public class GetAllBranchsRequest : IRequest<IEnumerable<BranchDto>>
{
}
