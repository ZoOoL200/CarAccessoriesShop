using CarAccessoriesShop.Application.DTOs.Contact.QueryDtos;

namespace CarAccessoriesShop.Application.DTOs.Supplier.Query;

public class SupplierWithContactDto
{
    public Guid Id { get; set; }
    public string SupplierName { get; set; } = default!;
    public string? Address { get; set; }
    public Guid PersonContactID { get; set; }

    public IList<ShowPersonContactDto> PersonContacts { get; set; } = [];
}
