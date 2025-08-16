
namespace CarAccessoriesShop.Application.DTOs.Contact;

public class RequestContactDto 
{
    public int Id { get; set; } 
    public string PersonName { get; set; } = default!;
    public string CountryName { get; set; } = default!;
    public string Key { get; set; } = default!;
    public string Telephone { get; set; } = default!;
}

