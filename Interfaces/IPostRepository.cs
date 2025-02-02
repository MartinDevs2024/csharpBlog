using csharpBlog.Models;

namespace csharpBlog.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        void Update(Post post); // Method to update a post
    }
}
