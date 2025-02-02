using csharpBlog.Interfaces;
using csharpBlog.Models.Comments;
using csharpBlog.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace csharpBlog.Areas.UI.Controllers
{
    [Area("UI")]
    public class PostController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var posts = _unitOfWork.Post.GetAll().ToList();
            return View(posts);
        }

        public IActionResult Detail(int id)
        {
            var post = _unitOfWork.Post.GetFirstOrDefault(p => p.Id == id, "Category");
            if (post == null)
                return NotFound();

            return View(post);
        }

        //[HttpPost]
        //public async Task<IActionResult> Comment(CommentViewModel vm)
        //{
        //    if (!ModelState.IsValid)
        //        return RedirectToAction("Post", new { id = vm.PostId });
        //    var post = _repo.GetPost(vm.PostId);

        //    if (vm.MainCommentId == 0)
        //    {
        //        post.MainComments = post.MainComments ?? new List<MainComment>();

        //        post.MainComments.Add(new MainComment
        //        {
        //            Message = vm.Message,
        //            Created = DateTime.Now
        //        });
        //        _repo.UpdatePost(post);
        //    }
        //    else 
        //    {
        //        var comment = new SubComment
        //        {
        //            MainCommentId = vm.MainCommentId,
        //            Message = vm.Message,
        //            Created = DateTime.Now,
        //        };
        //        _repo.AddSubComment(comment);
        //    }
        //    await _repo.SaveChangeAsync();
        //    return RedirectToAction("Detail", new { id = vm.PostId });
        //}
    }
}
