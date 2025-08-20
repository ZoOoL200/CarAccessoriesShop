namespace CarAccessoriesShop.Application.DTOs.Supplier.Query;

public class SupplierDto
{
    public Guid Id { get; set; }
    public string SupplierName { get; set; } = default!;
    public string? Address { get; set; }
    public Guid PersonContactID { get; set; }
}
