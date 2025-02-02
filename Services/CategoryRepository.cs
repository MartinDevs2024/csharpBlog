using csharpBlog.Data;
using csharpBlog.Interfaces;
using csharpBlog.Models;

namespace csharpBlog.Services
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        // Implementing the Update method
        public void Update(Category obj)
        {
            var categoryFromDb = _context.Categories.FirstOrDefault(c => c.Id == obj.Id);
            if (categoryFromDb != null)
            {
                categoryFromDb.Name = obj.Name;
                categoryFromDb.Description = obj.Description;
                // Add other fields you want to update
            }
        }
    }
}
