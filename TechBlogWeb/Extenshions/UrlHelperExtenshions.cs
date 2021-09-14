using Microsoft.AspNetCore.Mvc;

namespace TechBlogWeb.Extenshions
{
    public static class UrlHelperExtenshions
    {
        public static string GetLocalUrl(this IUrlHelper urlHelper, string localUrl)
        {
            if (!urlHelper.IsLocalUrl(localUrl))
            {
                return urlHelper.Page("/");
            }
            return localUrl;
        }
    }
}