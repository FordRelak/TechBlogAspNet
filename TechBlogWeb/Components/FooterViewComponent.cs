﻿using Microsoft.AspNetCore.Mvc;

namespace TechBlogWeb.Components
{
    public class FooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}