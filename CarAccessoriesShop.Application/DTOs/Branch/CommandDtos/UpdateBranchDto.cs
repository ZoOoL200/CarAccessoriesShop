namespace CarAccessoriesShop.Application.DTOs.Branch.CommandDtos;

public class UpdateBranchDto
{
    public Guid Id { get;  set; }
    public string Title { get; set; } = default!;
    public string? Location { get; set; }
}
