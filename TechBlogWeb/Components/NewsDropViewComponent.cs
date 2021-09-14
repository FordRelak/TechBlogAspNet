using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogWeb.Domain;
using TechBlogWeb.Domain.Repositories.Abstract;

namespace TechBlogWeb.Components
{
    public class NewsDropViewComponent : ViewComponent
    {
        readonly DataManager dataManager;
        public NewsDropViewComponent(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IViewComponentResult Invoke()
        {
            var model = dataManager.Articles.GetArticles().OrderBy(a => a.Tag)
                .ThenByDescending(a => a.DateTime);
            return View(model: model);
        }
    }
}
