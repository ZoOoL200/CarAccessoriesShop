namespace CarAccessoriesShop.Application.DTOs.Category.CommandDtos;

public class UpdateCategoryDto
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
}
