using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogWeb.Domain.Repositories.Abstract;

namespace TechBlogWeb.Domain
{
    public class DataManager
    {
        public IArticleRepository Articles { get; set; }

        public DataManager(IArticleRepository articleRepository)
        {
            Articles = articleRepository;
        }
    }
}
