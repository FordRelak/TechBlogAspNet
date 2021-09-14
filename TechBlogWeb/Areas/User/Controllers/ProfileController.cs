using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechBlogWeb.Areas.User.Models.ViewModels;

namespace TechBlogWeb.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "user")]
    public class ProfileController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

        public ProfileController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                var roles = await userManager.GetRolesAsync(user);
                return View(model: new UserProfileViewModel
                {
                    Roles = roles
                });
            }
            return View();
        }
    }
}