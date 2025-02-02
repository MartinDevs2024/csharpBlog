using csharpBlog.Data;
using csharpBlog.Interfaces;
using csharpBlog.Models;

namespace csharpBlog.Services
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Post post)
        {
            var objFromDb = _context.Posts.FirstOrDefault(p => p.Id == post.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = post.Title;
                objFromDb.Body = post.Body;
                objFromDb.Description = post.Description;
                objFromDb.Tags = post.Tags;
                objFromDb.CategoryId = post.CategoryId;
                if (!string.IsNullOrEmpty(post.Image))
                {
                    objFromDb.Image = post.Image;
                }
            }
        }
    }
}
