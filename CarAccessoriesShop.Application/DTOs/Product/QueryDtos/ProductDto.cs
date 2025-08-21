namespace CarAccessoriesShop.Application.DTOs.Product.QueryDtos;

internal class ProductDto
{
    public Guid Id { get; private set; }
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
    public string CategoryName { get; set; } = default!;
}
