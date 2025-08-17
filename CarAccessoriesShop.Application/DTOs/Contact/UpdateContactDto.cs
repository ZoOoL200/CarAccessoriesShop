
namespace CarAccessoriesShop.Application.DTOs.Contact;

public class UpdateContactDto 
{
    public long Id { get; set; }
    public string? Key { get; set; }
    public string Telephone { get; set; } = default!;
}
