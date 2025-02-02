using csharpBlog.Data;
using csharpBlog.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace csharpBlog.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        // Get the first entity that matches the filter
        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = true)
        {
            IQueryable<T> query = _dbSet;

            if (!tracked)
                query = query.AsNoTracking(); // If not tracked, use AsNoTracking() to improve performance

            if (filter != null)
                query = query.Where(filter);

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.FirstOrDefault();
        }

        // Get all entities matching the filter
        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.ToList();
        }

        // Add a new entity
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        // Remove an entity
        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        // Remove a range of entities
        public void RemoveRange(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
        }
    }
}
