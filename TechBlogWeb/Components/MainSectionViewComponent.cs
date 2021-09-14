using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TechBlogWeb.Domain;
using TechBlogWeb.Domain.Repositories.Abstract;

namespace TechBlogWeb.Components
{
    public class MainSectionViewComponent : ViewComponent
    {
        readonly DataManager dataManager;
        public MainSectionViewComponent(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IViewComponentResult Invoke()
        {
            //Выборка лучших за неделю (in progress)
            var week = DateTime.UtcNow.AddDays(-7);
            var model = dataManager.Articles.GetArticles().Where(a => a.DateTime.CompareTo(week) == 1).ToList();
            return View(model: model);
        }
    }
}