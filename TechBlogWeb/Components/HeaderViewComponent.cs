using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TechBlogWeb.Domain.Repositories.Abstract;

namespace TechBlogWeb.Components
{
    public class HeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}