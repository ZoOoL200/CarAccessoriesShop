using System.Linq.Expressions;

namespace CarAccessoriesShop.Application.Presistences.Contracts.Repos;

public interface IGeneralRepository<T> where T : class
{
    /// <summary>
    /// Asynchronously retrieves the first entity that matches the specified predicate,  optionally including related
    /// entities as specified.
    /// </summary>
    /// <param name="predicate">An expression that defines the condition to match. This cannot be <see langword="null"/>.</param>
    /// <param name="includes">An array of expressions specifying the related entities to include in the query.  This parameter is optional and
    /// can be empty.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the first  entity that matches the
    /// predicate, or <see langword="null"/> if no match is found.</returns>
    public Task<T> FindRowBy(
    Expression<Func<T, bool>> predicate,
    params Expression<Func<T, object>>[] includes);
    /// <summary>
    /// Finds a single row in the data source that matches the specified predicate.
    /// </summary>
    /// <remarks>This method is typically used to retrieve a single entity from a data source, optionally
    /// including related entities and applying ordering.</remarks>
    /// <typeparam name="Tkey">The type of the key used for ordering the results.</typeparam>
    /// <param name="predicate">An expression that specifies the condition to filter the rows. This parameter cannot be <see langword="null"/>.</param>
    /// <param name="orderBy">An optional expression to specify the ordering of the results. If provided, the first matching row based on this
    /// order will be returned.</param>
    /// <param name="includes">An optional array of expressions specifying related entities to include in the query results. Use this to
    /// eagerly load related data.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the first row that matches the
    /// predicate, or <see langword="null"/> if no match is found.</returns>
    public Task<T> FindRowBy<Tkey>(
     Expression<Func<T, bool>> predicate,
     Expression<Func<T, Tkey>>? orderBy = null,
     params Expression<Func<T, object>>[] includes);
    /// <summary>
    /// Asynchronously retrieves a collection of entities that match the specified predicate,  including related
    /// entities as specified by the include expressions.
    /// </summary>
    /// <remarks>This method is typically used to perform filtered queries with optional eager loading of 
    /// related entities. The <paramref name="includes"/> parameter allows specifying navigation  properties to include
    /// in the query, enabling efficient data retrieval for complex object graphs.</remarks>
    /// <param name="predicate">An expression that defines the conditions each entity must satisfy to be included in the result.</param>
    /// <param name="includes">An array of expressions specifying the related entities to include in the query results.  Each expression should
    /// indicate a navigation property to include.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains an  <IEnumerable{T}> of entities
    /// that match the specified predicate. If no entities  match, the result will be an empty collection.</returns>
    public Task<IEnumerable<T>> FindMultiRowsBy(
    Expression<Func<T, bool>> predicate,
    params Expression<Func<T, object>>[] includes);
    /// <summary>
    /// Retrieves multiple rows from the data source that match the specified predicate.
    /// </summary>
    /// <remarks>Use this method to retrieve multiple rows from the data source with optional ordering and
    /// eager loading of related entities.</remarks>
    /// <typeparam name="Tkey">The type of the key used for ordering the results.</typeparam>
    /// <param name="predicate">An expression that defines the conditions each row must satisfy.</param>
    /// <param name="orderBy">An optional expression to specify the property by which the results should be ordered. If null, no specific
    /// ordering is applied.</param>
    /// <param name="includes">An array of expressions specifying related entities to include in the query results.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable of rows of type
    /// <typeparamref name="T"/> that match the specified conditions.</returns>
    public Task<IEnumerable<T>> FindMultiRowsBy<Tkey>(
        Expression<Func<T, bool>> predicate,
        Expression<Func<T, Tkey>>? orderBy = null,
        params Expression<Func<T, object>>[] includes);
    /// <summary>
    /// Asynchronously retrieves all entities of type <typeparamref name="T"/> from the data source.
    /// </summary>
    /// <remarks>This method retrieves all entities from the data source and optionally orders them  based on
    /// the provided <paramref name="orderBy"/> expression. The operation is  asynchronous and does not block the
    /// calling thread.</remarks>
    /// <typeparam name="Tkey">The type of the key used for ordering the entities.</typeparam>
    /// <param name="orderBy">An optional expression specifying the property by which to order the entities.  If <see langword="null"/>, the
    /// entities are returned in their default order.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains an  <see cref="IEnumerable{T}"/> of
    /// all entities of type <typeparamref name="T"/>.</returns>
    public Task<IEnumerable<T>> GetAllAsync<Tkey>(Expression<Func<T, Tkey>>? orderBy = null);

    /// <summary>
    ///  Asynchronously retrieves all entities of type <typeparamref name="T"/> from the data source.
    /// </summary>
    /// <remarks>This method retrieves all entities from the data source and optionally orders them  based on
    /// the provided <paramref name="orderBy"/> expression and includes the relations in <paramref name="includes"/> experssion.
    /// The operation is  asynchronous and does not block the calling thread.</remarks>
    /// <typeparam name="Tkey">The type of the key used for ordering the entities.</typeparam>
    /// <param name="orderBy">>An optional expression specifying the property by which to order the entities.  If <see langword="null"/>, the
    /// entities are returned in their default order.</param>
    /// <param name="includes">Relations with entity <typeparamref name="T"/>.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains an  <see cref="IEnumerable{T}"/> of
    /// all entities of type <typeparamref name="T"/></returns>
    public Task<IEnumerable<T>> GetAllAsync<Tkey>(Expression<Func<T, Tkey>>? orderBy = null, params Expression<Func<T, object>>[] includes);

    /// <summary>
    /// Retrieves an entity of type <typeparamref name="T"/> by its unique identifier.
    /// </summary>
    /// <typeparam name="Tkey">The type of the unique identifier.</typeparam>
    /// <param name="id">The unique identifier of the entity to retrieve. Cannot be null.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the entity of type <typeparamref
    /// name="T"/>  if found; otherwise, <see langword="null"/>.</returns>
    public Task<T?> GetByIdAsync<Tkey>(Tkey id) ;

    /// <summary>
    /// Determines whether an entity with the specified identifier exists asynchronously.
    /// </summary>
    /// <typeparam name="TKey">The type of the identifier.</typeparam>
    /// <param name="id">The identifier of the entity to check for existence. Cannot be null.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains  <see langword="true"/> if an entity
    /// with the specified identifier exists; otherwise, <see langword="false"/>.</returns>
    public  Task<bool> IsExistsAsync<TKey>(TKey id);
    /// <summary>
    /// Determines whether any entities in the data source satisfy the specified condition.
    /// </summary>
    /// <remarks>This method is typically used to check for the existence of entities that match a specific
    /// condition  in the data source. The <paramref name="predicate"/> parameter must not be <see
    /// langword="null"/>.</remarks>
    /// <param name="predicate">An expression that defines the condition to test against the entities.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains  <see langword="true"/> if any
    /// entities satisfy the condition; otherwise, <see langword="false"/>.</returns>
    public  Task<bool> IsExistsAsync(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Asynchronously adds the specified entity to the data source.
    /// </summary>
    /// <param name="entity">The entity to add. Cannot be <see langword="null"/>.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task AddAsync(T entity) ;
    /// <summary>
    /// Asynchronously adds a collection of entities to the underlying data store.
    /// </summary>
    /// <remarks>Each entity in the collection will be added to the data store. The operation is performed
    /// asynchronously      to avoid blocking the calling thread. Ensure that the collection is not null or empty before
    /// calling this method.</remarks>
    /// <param name="entities">The collection of entities to add. Cannot be null or empty.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task AddAsync(IEnumerable<T> entities);

    /// <summary>
    /// Deletes the specified entity from the data store.
    /// </summary>
    /// <remarks>This method removes the specified entity from the underlying data store.  Ensure that the
    /// entity exists in the data store before calling this method to avoid unexpected behavior.</remarks>
    /// <param name="entity">The entity to delete. Cannot be <see langword="null"/>.</param>
    public void Delete(T entity) ;
    /// <summary>
    /// Deletes the specified collection of entities from the data store.
    /// </summary>
    /// <param name="entities">The collection of entities to delete. Cannot be null or contain null elements.</param>
    public void Delete(IEnumerable<T> entities);
    /// <summary>
    /// Updates the specified entity in the data store.
    /// </summary>
    /// <param name="entity">The entity to update. Must not be <see langword="null"/>.</param>
    public void Update(T entity) ;
    /// <summary>
    /// Updates the specified collection of entities in the data store.
    /// </summary>
    /// <remarks>The method assumes that the provided entities are valid and have their identifiers set. If an
    /// entity does not exist in the data store, the behavior is undefined and may result in an error.</remarks>
    /// <param name="entities">A collection of entities to be updated. Each entity must already exist in the data store.</param>
    public void Update(IEnumerable<T> entities);
}
