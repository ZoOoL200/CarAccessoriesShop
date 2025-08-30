using CarAccessoriesShop.Domain.Entity.Main;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarAccessoriesShop.Domain.Entity.Operations;
[Index(nameof(TransferNumber), IsUnique = true)]
public class ProductTransfer
{
    public long Id { get; set; }

    [MaxLength(25)]
    public string TransferNumber { get; set; } = default!;

    [ForeignKey(nameof(FromInventory))]
    public Guid FromInventoryId { get; set; }

    [ForeignKey(nameof(ToInventory))]
    public Guid ToInventoryId { get; set; }
    public DateTime TransferDate { get; set; }
    public Guid EmployeeID { get; set; }
    public string? Description { get; set; }

    // Navigation properties
    public Inventory FromInventory { get; set; } = default!;
    public Inventory ToInventory { get; set; } = default!;
    public ICollection<ProductTransferDetail> ProductTransferDetails { get; set; } = [];
    // Tdo: Add Employee navigation property when Employee entity is created
}
