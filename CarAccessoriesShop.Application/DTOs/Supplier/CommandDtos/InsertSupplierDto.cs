namespace CarAccessoriesShop.Application.DTOs.Supplier.CommandDtos;

public class InsertSupplierDto
{
    public string SupplierName { get; set; } = default!;
    public string? Address { get; set; }
}
