using System.Linq.Expressions;

namespace csharpBlog.Interfaces
{
    public interface IRepository<T> where T : class
    {
        // Get the first entity matching the filter (or default)
        T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = true);

        // Get all entities matching the filter
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);

        // Add a new entity
        void Add(T entity);

        // Remove an entity
        void Remove(T entity);

        // Remove a range of entities
        void RemoveRange(IEnumerable<T> entity);

    }
}
