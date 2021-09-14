using System;

namespace TechBlogWeb.Models
{
    public class PageInfo
    {
        public int TotalArticle { get; set; }
        public int ArticlePerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages =>
            (int)Math.Ceiling((decimal)TotalArticle / ArticlePerPage);
    }
}