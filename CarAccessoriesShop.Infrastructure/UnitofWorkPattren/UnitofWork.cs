using CarAccessoriesShop.Application.Presistences.Contracts.Repos;
using CarAccessoriesShop.Application.Presistences.UnitofWork;
using CarAccessoriesShop.Domain.Entity.HR;
using CarAccessoriesShop.Domain.Entity.Main;
using CarAccessoriesShop.Infrastucture.Persistence;
using MarCarAccessoriesShopket.Domain.Entity.Main;
using Microsoft.EntityFrameworkCore.Storage;

namespace CarAccessoriesShop.Infrastucture.UnitofWorkPattren;

internal class UnitofWork(AppDbContext context, Lazy<IGeneralRepository<Contact>> contactRepo , Lazy<IGeneralRepository<CountryKey>> countryKeyRepo ,
    Lazy<IGeneralRepository<Supplier>> supplierRepo, Lazy<IGeneralRepository<Person>> personRepo 
    , Lazy<IGeneralRepository<Branch>> branchRepo, Lazy<IGeneralRepository<Product>> productRepo, Lazy<IGeneralRepository<Category>> categoryRepo) : IUnitofWork
{
    private IDbContextTransaction? transaction;




    // Rrpositories
    public IGeneralRepository<Person> PersonRepo => personRepo.Value;
    public IGeneralRepository<Contact> ContactRepo => contactRepo.Value;
    public IGeneralRepository<CountryKey> CountryKeyRepo => countryKeyRepo.Value;
    public IGeneralRepository<Supplier> SupplierRepo => supplierRepo.Value;
    public IGeneralRepository<Branch> BranchRepo => branchRepo.Value;

    public IGeneralRepository<Category> CategoryRepo => categoryRepo.Value;

    public IGeneralRepository<Product> ProductRepo => productRepo.Value;


    //Methods
    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default) 
    {
        transaction = await context.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (transaction != null)
        {
            await transaction.CommitAsync(cancellationToken);
            await transaction.DisposeAsync();
            transaction = null;
        }
    }

    public void Dispose()
    {
        context.Dispose();
        transaction?.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default) 
    {
        if (transaction != null)
        {
            await transaction.RollbackAsync(cancellationToken);
            await transaction.DisposeAsync();
            transaction = null;
        }
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
       return await context.SaveChangesAsync(cancellationToken);
    }
}
