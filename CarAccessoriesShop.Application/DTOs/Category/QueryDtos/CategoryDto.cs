namespace CarAccessoriesShop.Application.DTOs.Category.QueryDtos;

public class CategoryDto
{
    public short Id { get; set; }
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
}
