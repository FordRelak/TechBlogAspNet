using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogWeb.Domain;
using TechBlogWeb.Domain.Repositories.Abstract;

namespace TechBlogWeb.Components
{
    public class SideBarViewComponent : ViewComponent
    {
        private readonly DataManager dataManager;
        public SideBarViewComponent(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult((IViewComponentResult)View(dataManager.Articles.GetArticles()));
        }
    }
}
