using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TechBlogWeb.Domain;
using TechBlogWeb.Models;
using TechBlogWeb.Models.ViewModel;

namespace TechBlogWeb.Components
{
    public class RecentNewsViewComponent : ViewComponent
    {
        private readonly DataManager dataManager;
        private int pageSize = 10;

        public RecentNewsViewComponent(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IViewComponentResult Invoke()
        {
            object articlePage = 1;
            if (Request.RouteValues.ContainsKey("articlePage"))
            {
                Request.RouteValues.TryGetValue("articlePage", out articlePage);
            }
            var aP = int.Parse(articlePage.ToString());
            return View(model: new ArticleListViewModel()
            {
                Articles = dataManager.Articles.GetArticles()
                    .OrderByDescending(a => a.DateTime)
                    .Skip((aP - 1) * pageSize)
                    .Take(10)
                    .ToList(),
                PageInfo = new PageInfo
                {
                    ArticlePerPage = pageSize,
                    CurrentPage = aP,
                    TotalArticle = dataManager.Articles.GetArticles().Count()
                }
            });
        }
    }
}