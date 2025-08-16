using CarAccessoriesShop.Domain.Entity.Operations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarAccessoriesShop.Domain.Entity.HR;

public class Supplier
{
    [Key]
    public Guid Id { get; set; }

    [MaxLength(50)]
    [Required]
    public string SupplierName { get; set; } = default!;

    public string? Address { get; set; }

    [ForeignKey(nameof(Person))]
    [Required]
    public Guid PersonContactID { get; set; }

    // Navigation properties
    public Person Person { get; set; } = default!;
    public ICollection<PurchaseInvoice> PurchaseInvoices { get; set; } = new List<PurchaseInvoice>();
}
