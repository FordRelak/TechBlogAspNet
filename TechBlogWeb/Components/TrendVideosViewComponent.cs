using Microsoft.AspNetCore.Mvc;

namespace TechBlogWeb.Components
{
    public class TrendVideosViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}