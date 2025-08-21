namespace CarAccessoriesShop.Application.DTOs.Contact.CommandDtos;

public class CreatContactDto 
{
    public Guid PersonID { get; set ; }
    public string Key { get; set; } = default!;
    public string Telephone { get; set; } = default!;
}
