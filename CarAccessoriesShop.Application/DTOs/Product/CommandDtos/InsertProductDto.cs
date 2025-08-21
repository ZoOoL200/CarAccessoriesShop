namespace CarAccessoriesShop.Application.DTOs.Product.CommandDtos;

public class InsertProductDto
{
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
    public short CategoryID { get; set; }
}
