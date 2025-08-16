using System.ComponentModel.DataAnnotations;

namespace CarAccessoriesShop.Domain.Entity.HR;

public class Person
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string ReferenceType { get; set; } = default!;

    // Navigation properties
    public Supplier Supplier { get; set; } = default!;
    public ICollection<Contact> Contact { get; set; } = new List<Contact>();
}
