using csharpBlog.Interfaces;
using csharpBlog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace csharpBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IRepository _repo;

        public PostsController(IRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Post
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            var posts =_repo.GetAllPosts();
            return Ok(posts);
        }
    }
}
