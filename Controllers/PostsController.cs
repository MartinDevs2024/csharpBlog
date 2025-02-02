using csharpBlog.Interfaces;
using csharpBlog.Models;
using Microsoft.AspNetCore.Mvc;

namespace csharpBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Post
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            var posts = _unitOfWork.Post.GetAll().ToList(); 
            return Ok(posts);
        }
    }
}
