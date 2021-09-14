using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogWeb.Domain.Entites;
using TechBlogWeb.Models.ViewModel;

namespace TechBlogWeb.Models.ViewModel
{
    public class ArticleListViewModel
    {
        public List<Article> Articles { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
