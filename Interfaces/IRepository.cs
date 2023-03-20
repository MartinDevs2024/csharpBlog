using csharpBlog.Models;
using csharpBlog.Models.Comments;

namespace csharpBlog.Interfaces
{
    public interface IRepository
    {
        Post GetPost(int id);
        List<Post> GetAllPosts();
        void AddPost(Post post);
        void UpdatePost(Post post);
        void RemovePost(int id);
        void AddSubComment(SubComment comment);
        Task<bool> SaveChangeAsync();

    }
}
