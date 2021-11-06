using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleTaskWeb.Server.Repositories
{
  /// <summary>
  /// Generic repository - base for domain specific repositories
  /// </summary>
  /// <typeparam name="T">Any model class</typeparam>
  public interface IGenericRepository<T> where T : class
  {
    /// <summary>
    /// Gets all entities async
    /// </summary>
    /// <returns>Enumerable list of all entties</returns>
    Task<IEnumerable<T>> GetAllAsync();

    /// <summary>
    /// Adds a new entity async
    /// </summary>
    /// <param name="entity">The entity to be added</param>
    /// <returns>The added entity</returns>
    Task<T> AddAsync(T entity);

    /// <summary>
    /// Deletes the given entity async
    /// </summary>
    /// <param name="entity">The entity to be deleted</param>
    Task DeleteAsync(T entity);  
  }
}
