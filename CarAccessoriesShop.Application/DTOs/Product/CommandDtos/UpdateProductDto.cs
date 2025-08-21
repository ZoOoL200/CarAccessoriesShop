namespace CarAccessoriesShop.Application.DTOs.Product.CommandDtos
{
    public class UpdateProductDto
    {
        public Guid Id { get; private set; }
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public short CategoryID { get; set; }
    }
}
