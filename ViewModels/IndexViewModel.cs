﻿using csharpBlog.Models;
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
    }
}
