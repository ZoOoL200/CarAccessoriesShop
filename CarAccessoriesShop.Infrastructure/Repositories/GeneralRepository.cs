using CarAccessoriesShop.Application.Exceptions;
using CarAccessoriesShop.Application.Presistences.Contracts.Repos;
using CarAccessoriesShop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarAccessoriesShop.Infrastructure.Repositories;

internal class GeneralRepository<T>(AppDbContext dbcontext) : IGeneralRepository<T> where T : class
{
    private readonly DbSet<T> dbset = dbcontext.Set<T>();

    //Search for one row by specific column
    public async Task<T?> FindRowBy(
    Expression<Func<T, bool>> predicate,
    params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = dbset.Where(predicate);

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.FirstOrDefaultAsync();
    }
    public async Task<T?> FindRowBy<Tkey>(
     Expression<Func<T, bool>> predicate,
     Expression<Func<T, Tkey>>? orderBy = null,
     params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = dbset.Where(predicate);

        //  Includes 
        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        // order 
        if (orderBy != null)
            query = query.OrderBy(orderBy);

        // return the first or default entity that matches the criteria
        return await query.FirstOrDefaultAsync();
    }

    // Search for multi-Rows by specific column
    public async Task<IEnumerable<T>> FindMultiRowsBy(
    Expression<Func<T, bool>> predicate,
    params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = dbset.Where(predicate);

        // Includes
        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        var list = await query.ToListAsync();

        return list;
    }
    public async Task<IEnumerable<T>> FindMultiRowsBy<Tkey>(
        Expression<Func<T, bool>> predicate,
        Expression<Func<T, Tkey>>? orderBy = null,
        params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = dbset.Where(predicate);

        // Includes
        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        // order 
        if (orderBy != null)
            query = query.OrderBy(orderBy);

        var list = await query.ToListAsync();

        return list;
    }

    // retrieves all entities of type T from the data source asynchronously with or without order.
    public async Task<IEnumerable<T>> GetAllAsync<Tkey>(Expression<Func<T, Tkey>>? orderBy = null)

    {
        var query = dbset.AsNoTracking().AsQueryable();

        if (orderBy != null)
            query = query.OrderBy(orderBy);

        return await query.ToListAsync();
    }
    public async Task<IEnumerable<T>> GetAllAsync<Tkey>(Expression<Func<T, Tkey>>? orderBy = null , params Expression<Func<T, object>>[] includes)

    {
        var query = dbset.AsNoTracking().AsQueryable();
        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        if (orderBy != null)
            query = query.OrderBy(orderBy);

        return await query.ToListAsync();
    }

    // retrieves an entity by its unique identifier asynchronously.
    public async Task<T?> GetByIdAsync<Tkey>(Tkey id) => await dbset.FindAsync(id);
   
    // checks if an entity with the specified unique identifier exists in the data source asynchronously.
    public async Task<bool> IsExistsAsync<TKey>(TKey id)
    {
        var keyName = dbcontext.Model.FindEntityType(typeof(T))
                        ?.FindPrimaryKey()?.Properties.Select(p => p.Name).Single();

        if (keyName is null)
            throw new InvalidOperationException($"No primary key found for entity {typeof(T).Name}.");

        return await dbset.AsNoTracking().AnyAsync(entity => EF.Property<TKey>(entity, keyName)!.Equals(id));
    }
    public async Task<bool> IsExistsAsync(Expression<Func<T, bool>> predicate)
    {
        return await dbset.AsNoTracking().AnyAsync(predicate);
    }

    // Adds a new entity to the data store asynchronously.
    public async Task AddAsync(T entity) => await dbset.AddAsync(entity);
    public async Task AddAsync(IEnumerable<T> entities) => await dbset.AddRangeAsync(entities);

    // Deletes the specified entity from the data store.
    public void Delete(T entity) => dbset.Remove(entity);
    public void Delete(IEnumerable<T> entities) => dbset.RemoveRange(entities);

    // Updates the specified entity in the data store.
    public void Update(T entity) => dbset.Update(entity);
    public void Update(IEnumerable<T> entities) => dbset.UpdateRange(entities);
}
