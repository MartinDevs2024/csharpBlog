using csharpBlog.Data;
using csharpBlog.Interfaces;

namespace csharpBlog.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Category = new CategoryRepository(_context);
            Post = new PostRepository(_context);
        }
        public ICategoryRepository Category { get; private set; }

        public IPostRepository Post { get; private set; } 

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
