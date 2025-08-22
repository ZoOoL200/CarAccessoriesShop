namespace CarAccessoriesShop.Application.DTOs.Category.CommandDtos;

public class InsertCategoryDto
{
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
}
