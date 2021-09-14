using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TechBlogWeb.Domain;
using TechBlogWeb.Domain.Entites;

namespace TechBlogWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="admin")]
    public class ArticleItemController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostEnvironment;

        public ArticleItemController(DataManager dataManager, IWebHostEnvironment hostEnvironment)
        {
            this.dataManager = dataManager;
            this.hostEnvironment = hostEnvironment;
        }

        public IActionResult Edit(Guid id)
        {
            var entity = id == default ? new Article() : dataManager.Articles.GetArticleById(id);
            ViewBag.Tags = new SelectList(dataManager.Articles
                                            .GetArticles()
                                            .Select(a => a.NormalizedTag)
                                            .Distinct());
            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Article model, IFormFile titleImagePath)
        {
            if (ModelState.IsValid)
            {
                if (titleImagePath != null)
                {
                    model.TitleImagePath = titleImagePath.FileName;
                    using (var stream = new FileStream(Path.Combine(hostEnvironment.WebRootPath, "images/", titleImagePath.FileName), FileMode.Create))
                    {
                        titleImagePath.CopyTo(stream);
                    }
                }
                model.Tag = model.NormalizedTag.Replace(" ", "");
                await dataManager.Articles.SaveArticleAsync(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", ""));
            }
            return View(model);
        }
    }
}