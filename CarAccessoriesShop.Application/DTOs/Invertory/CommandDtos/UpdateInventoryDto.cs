namespace CarAccessoriesShop.Application.DTOs.Invertory.CommandDtos;

public class UpdateInventoryDto
{
    public Guid Id { get; private set; }
    public string Title { get; set; } = default!;
    public Guid BranchID { get; set; }
}
