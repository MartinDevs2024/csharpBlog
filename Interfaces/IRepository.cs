using csharpBlog.Models;
using csharpBlog.Models.Comments;
using csharpBlog.ViewModels;

namespace csharpBlog.Interfaces
{
    public interface IRepository
    {
        Post GetPost(int id);
        IndexViewModel GetAllPosts(int pageNumber, string category, string search);
        List<Post> GetAllPosts();
        void AddPost(Post post);
        void UpdatePost(Post post);
        void RemovePost(int id);
        void AddSubComment(SubComment comment);
        Task<bool> SaveChangeAsync();

    }
}
