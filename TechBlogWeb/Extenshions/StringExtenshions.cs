using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechBlogWeb.Extenshions
{
    public static class StringExtenshions
    {
        /// <summary>
        /// "Отрезает" controller в имени контроллера. "HomeController" -> "Home"
        /// </summary>
        /// <param name="controller">Название контроллера</param>
        /// <returns>Строка без "Controller"</returns>
        public static string CutController(this string controller)
        {
            return controller.Replace("Controller", "");
        }
    }
}
