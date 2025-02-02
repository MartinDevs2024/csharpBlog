
namespace csharpBlog.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string? Description { get; set; }

        // Navigation property
        public List<Post> Posts { get; set; } = new();
    }
}