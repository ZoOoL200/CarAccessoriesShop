namespace CarAccessoriesShop.Application.DTOs.Invertory.CommandDtos;

public class InsertInvetoryDto
{
    public string Title { get; set; } = default!;
    public Guid BranchID { get; set; }
}
