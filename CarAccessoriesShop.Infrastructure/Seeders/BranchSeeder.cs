using CarAccessoriesShop.Domain.Entity.Main;
using CarAccessoriesShop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarAccessoriesShop.Infrastructure.Seeders;

public interface IBranchSeeder
{
    /// <summary>
    /// Seed Branches
    /// </summary>
    /// <returns></returns>
    public Task SeedAsync();
}


internal class BranchSeeder(AppDbContext dbContext) : IBranchSeeder
{

    public async Task SeedAsync()
    {

        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Branches.Any())
            {
                var branches = GetBranchs();
                await dbContext.Branches.AddRangeAsync(branches);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<Branch> GetBranchs() =>
        [
            new Branch()
            {
                Title = "الفرع الرئيسي",
                Location = null,
                Inventories =
                [
                    new Inventory()
                    {
                        Title = "المخزن الرئيسي"
                    }
                ]
                
            }
        ];

}
            