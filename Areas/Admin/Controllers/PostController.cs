using csharpBlog.Interfaces;
using csharpBlog.Models;
using csharpBlog.Utility;
using csharpBlog.ViewModels;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace csharpBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class PostController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileManager _fileManager;

        public PostController(IUnitOfWork unitOfWork, IFileManager fileManager)
        {
            _unitOfWork = unitOfWork;
            _fileManager = fileManager;
        }

        public IActionResult Index()
        {
            var posts = _unitOfWork.Post.GetAll();
            return View(posts);
        }

        public IActionResult Create()
        {
            var viewModel = new PostViewModel
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var post = new Post
                {
                    Title = vm.Title,
                    Body = vm.Body,
                    Description = vm.Description,
                    Tags = vm.Tags,
                    CategoryId = vm.CategoryId,
                    Image = vm.Image == null ? null : await _fileManager.SaveImage(vm.Image)
                };

                _unitOfWork.Post.Add(post);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        public IActionResult Edit(int id)
        {
            var post = _unitOfWork.Post.GetFirstOrDefault(p => p.Id == id);
            if (post == null)
                return NotFound();

            var viewModel = new PostViewModel
            {
                Id = post.Id,
                Title = post.Title,
                Body = post.Body,
                Description = post.Description,
                Tags = post.Tags,
                CategoryId = post.CategoryId,
                CurrentImage = post.Image,
                CategoryList = _unitOfWork.Category.GetAll().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PostViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var post = _unitOfWork.Post.GetFirstOrDefault(p => p.Id == vm.Id);
                if (post == null)
                    return NotFound();

                post.Title = vm.Title;
                post.Body = vm.Body;
                post.Description = vm.Description;
                post.Tags = vm.Tags;
                post.CategoryId = vm.CategoryId;
                post.Image = vm.Image == null ? vm.CurrentImage : await _fileManager.SaveImage(vm.Image);

                _unitOfWork.Post.Update(post);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        public IActionResult Delete(int id)
        {
            var post = _unitOfWork.Post.GetFirstOrDefault(p => p.Id == id);
            if (post == null)
                return NotFound();

            _unitOfWork.Post.Remove(post);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}







