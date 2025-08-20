namespace CarAccessoriesShop.Application.DTOs.Contact.CommandDtos;

public class UpdateContactDto 
{
    public long Id { get; set; }
    public string Key { get; set; } = default!;
    public string Telephone { get; set; } = default!;
}
