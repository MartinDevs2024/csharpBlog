using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace csharpBlog.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Body { get; set; } = "";
        public string Description { get; set; } = "";
        public string Tags { get; set; } = "";

        public int CategoryId { get; set; }
        // This will hold the categories for the dropdown
        [ValidateNever]  
        public IEnumerable<SelectListItem>? CategoryList { get; set; } 
        public string CurrentImage { get; set; } = "";
        public IFormFile Image { get; set; } = null;
    }
}
