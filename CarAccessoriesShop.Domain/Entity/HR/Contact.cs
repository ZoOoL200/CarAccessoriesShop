using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarAccessoriesShop.Domain.Entity.HR;
public class Contact
{
    [Key]
    public long Id { get; set; }

    [ForeignKey(nameof(person))]
    [Required]
    public Guid PersonID { get; set; }

    [Required]
    [ForeignKey(nameof(Country))]
    public int CountryID { get; set; }

    [Required]
    public string Telephone { get; set; } = default!;
    // navigation property
    public CountryKey Country { get; set; } = default!;
    public Person person { get; set; } = default!;
}
