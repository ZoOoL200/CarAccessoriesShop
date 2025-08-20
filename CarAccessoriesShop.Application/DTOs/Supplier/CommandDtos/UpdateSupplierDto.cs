namespace CarAccessoriesShop.Application.DTOs.Supplier.CommandDtos;

public class UpdateSupplierDto
{
    public Guid Id { get; set; }
    public string SupplierName { get; set; } = default!;
    public string? Address { get; set; }
}
