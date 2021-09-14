using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogWeb.Domain;

namespace TechBlogWeb.Areas.Admin.Components
{
    public class NavigatorTagViewComponent : ViewComponent
    {
        private readonly DataManager dataManager;

        public NavigatorTagViewComponent(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IViewComponentResult Invoke()
        {
            return View(model: dataManager.Articles
                .GetArticles()
                .Select(a => a.Tag)
                .Distinct());
        }
    }
}
