using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TechBlogWeb.Domain;
using TechBlogWeb.Models;
using TechBlogWeb.Models.ViewModel;

namespace TechBlogWeb.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "admin")]
    public class HomeController : Controller
    {
        private int pageSize = 10;
        private readonly DataManager dataManager;

        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index(string tag, int articlePage = 1)
        {
            ViewBag.SelectedTag = RouteData?.Values["tag"];
            return View(model: new ArticleListViewModel()
            {
                Articles = dataManager.Articles.GetArticles()
                .Where(a => tag == null || a.Tag == tag)
                    .OrderByDescending(a => a.DateTime)
                    .Skip((articlePage - 1) * pageSize)
                    .Take(10)
                    .ToList(),
                PageInfo = new PageInfo
                {
                    ArticlePerPage = pageSize,
                    CurrentPage = articlePage,
                    TotalArticle = dataManager.Articles.GetArticles()
                        .Where(a => tag == null || a.Tag == tag).Count()
                }
            });
        }
    }
}