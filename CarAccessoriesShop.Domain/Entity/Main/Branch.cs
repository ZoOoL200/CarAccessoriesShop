using CarAccessoriesShop.Domain.Entity.Operations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CarAccessoriesShop.Domain.Entity.Main;

[Index(nameof(Title), IsUnique = true)]
public class Branch
{
    [Key]
    public Guid Id { get; private set; }

    [MaxLength(30)]
    [Required]
    public string Title { get; set; } = default!;

    [MaxLength(100)]
    public string? Location { get; set; } 

    // Navigation properties
    public ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
    public ICollection<PurchaseInvoice> PurchaseInvoices { get; set; } = new List<PurchaseInvoice>();
    public ICollection<SalesInvoice> SalesInvoices { get; set; } = new List<SalesInvoice>();
}
