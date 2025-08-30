using CarAccessoriesShop.Domain.Entity.Main;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarAccessoriesShop.Domain.Entity.Operations;

public class PurchaseDetail
{
    [Key]
    public long Id { get; set; }

    [ForeignKey(nameof(PurchaseInvoice))]
    [Required]
    public long PurchaseInvoiceId { get; set; }

    [ForeignKey(nameof(Product) )]
    [Required]
    public Guid ProductId { get; set; }

    [Required]
    public int Quantity { get; set; }

    [Required]
    public decimal UnitPrice { get; set; } 
    public decimal TotalPrice  { get; private set; }

    // Navigation properties
    public PurchaseInvoice PurchaseInvoice { get; set; } = default!;
    public Product Product { get; set; } = default!;

}
