namespace CarAccessoriesShop.Application.DTOs.Contact.QueryDtos;

public class ShowContactDto 
{
    public long Id { get; set; } 
    public string PersonName { get; set; } = default!;
    public string CountryName { get; set; } = default!;
    public string Key { get; set; } = default!;
    public string Telephone { get; set; } = default!;
}

