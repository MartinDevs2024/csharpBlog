using csharpBlog.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.Metrics;

namespace csharpBlog.ViewModels
{
    public class IndexViewModel
    {
        public int PageNumber { get; set; }
        public bool NextPage { get; set; }
        public int PageCount { get; set; }
        public string Category { get; set; }
        public string Search { get; set; }
        public string OrderBy { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<int> Pages { get; internal set; }
          // Add CategoryList property
        public IEnumerable<SelectListItem> CategoryList { get; set; } //
    }
}
