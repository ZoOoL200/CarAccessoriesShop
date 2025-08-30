using CarAccessoriesShop.Domain.Entity.Main;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarAccessoriesShop.Domain.Entity.Operations;

public class ProductTransferDetail
{
    public long Id { get; set; }

    [ForeignKey(nameof(ProductTransfer))]
    public long TransferId { get; set; }

    [ForeignKey(nameof(Product))]
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal CostPrice { get; set; }
    public bool Approved { get; set; }
    public Guid? ApprovedBy { get; set; }
    public DateTime? ApprovedDate { get; set; }

    // Navigation properties
    public ProductTransfer ProductTransfer { get; set; } = default!;
    public Product Product { get; set; } = default!;
}
