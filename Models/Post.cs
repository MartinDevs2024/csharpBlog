using System.ComponentModel.DataAnnotations.Schema;
using csharpBlog.Models.Comments;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace csharpBlog.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Body { get; set; } = "";
        public string Image { get; set; } = "";
        public string Description { get; set; } = "";
        public string Tags { get; set; } = "";
        public DateTime Created { get; set; } = DateTime.Now;

        // Foreign Key for Category
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        // Foreign Key for User
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public List<MainComment> MainComments { get; set; } = new();
    }
}
