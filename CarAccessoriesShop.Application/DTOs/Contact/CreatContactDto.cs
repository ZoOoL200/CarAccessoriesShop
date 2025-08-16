
namespace CarAccessoriesShop.Application.DTOs.Contact;

public class CreatContactDto 
{
    public Guid PersonID { get; set ; }
    public string? Key { get ; set ; } 
    public string Telephone { get; set; } = default!;
}
