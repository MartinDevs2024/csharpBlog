using csharpBlog.Models;

namespace csharpBlog.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category obj);
    }
}
