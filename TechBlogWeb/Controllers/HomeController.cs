using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TechBlogWeb.Domain;
using TechBlogWeb.Models;
using TechBlogWeb.Models.ViewModel;

namespace TechBlogWeb.Controllers
{
    public class HomeController : Controller
    {
        private int pageSize = 12;
        private readonly DataManager dataManager;

        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Gadgets()
        {
            object articlePage = 1;
            if (Request.RouteValues.ContainsKey("articlePage"))
            {
                Request.RouteValues.TryGetValue("articlePage", out articlePage);
            }
            var aP = int.Parse(articlePage.ToString());
            return View(viewName: nameof(Gadgets),
                model: new ArticleListViewModel()
                {
                    Articles = dataManager.Articles.GetArticlesByTag(nameof(Gadgets))
                    .OrderByDescending(a => a.DateTime)
                    .Skip((aP - 1) * pageSize)
                    .Take(10)
                    .ToList(),
                    PageInfo = new PageInfo
                    {
                        ArticlePerPage = pageSize,
                        CurrentPage = aP,
                        TotalArticle = dataManager.Articles.GetArticlesByTag(nameof(Gadgets))
                        .Count()
                    }
                });
        }
    }
}