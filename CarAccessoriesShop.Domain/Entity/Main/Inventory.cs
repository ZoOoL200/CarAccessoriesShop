using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarAccessoriesShop.Domain.Entity.Main;

[Index(nameof(Title), IsUnique = true)]
public class Inventory
{
    [Key]
    public Guid Id { get; private set; }

    [MaxLength(30)]
    [Required]
    public string Title { get; set; } = default!;

    [ForeignKey(nameof(Branch))]
    [Required]
    public Guid BranchID { get; set; }

    // Navigation properties
    public Branch Branch { get; set; } = default!;
    public ICollection<ProductStock> ProductStocks { get; set; } = [];
}
