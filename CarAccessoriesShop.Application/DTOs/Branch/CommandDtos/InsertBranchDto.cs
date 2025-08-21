namespace CarAccessoriesShop.Application.DTOs.Branch.CommandDtos;

 public class InsertBranchDto
{
    public string Title { get; set; } = default!;
    public string? Location { get; set; }
}
