namespace CarAccessoriesShop.Application.DTOs.Branch.QueryDtos;

public class BranchDto
{
    public Guid Id { get;  set; }
    public string Title { get; set; } = default!;
    public string? Location { get; set; }
}
