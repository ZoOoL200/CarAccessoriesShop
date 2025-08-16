using CarAccessoriesShop.Domain.Entity.HR;
using CarAccessoriesShop.Domain.Entity.Main;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarAccessoriesShop.Domain.Entity.Operations;

public class PurchaseInvoice
{
    [Key]
    public long Id { get; set; }

    [ForeignKey(nameof(Supplier))]
    [Required]
    public Guid SupplierID { get; set; }

    [ForeignKey(nameof(Branch))]
    [Required]
    public Guid BranchID { get; set; }

    [Required]
    public DateTime PurchaseDate { get; private set; }

    public decimal TotalAmount { get; private set; } 

    // Navigation properties
    public Supplier Supplier { get; set; } = default!;
    public Branch Branch { get; set; } = default!;
    public ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();
}
