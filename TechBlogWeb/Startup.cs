using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TechBlogWeb.Domain;
using TechBlogWeb.Domain.Repositories.Abstract;
using TechBlogWeb.Domain.Repositories.EntityFramework;
using TechBlogWeb.Services;

namespace TechBlogWeb
{
    public class Startup
    {
        public IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            Configuration.Bind("Project", new Config());

            services.AddTransient<IArticleRepository, EFArticleRepository>();
            services.AddTransient<DataManager>();

            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));

            services.AddIdentity<IdentityUser, IdentityRole>(opt =>
            {
                opt.User.RequireUniqueEmail = false;
                opt.Password.RequiredLength = 6;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "techblogcookie";
                opt.Cookie.HttpOnly = true;
                opt.LoginPath = "/account/login";
                opt.AccessDeniedPath = "/account/accessdenied";
                opt.SlidingExpiration = true;
            });

            services.AddAuthorization(x =>
                {
                    x.AddPolicy("AdminArea", policy =>
                        {
                            policy.RequireRole("admin");
                        });
                    x.AddPolicy("UserArea", policy =>
                    {
                        policy.RequireRole("user");
                    });
                });

            services.AddControllersWithViews(x =>
                {
                    x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
                    x.Conventions.Add(new UserAreaAuthorization("User", "UserArea"));
                })
                .AddRazorRuntimeCompilation()
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0)
                .AddSessionStateTempDataProvider();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: null,
                    areaName: "Admin",
                    pattern: "Admin/{tag}/{articlePage:int}",
                    defaults: new { controller = "Home", action = "Index" });

                endpoints.MapAreaControllerRoute(
                    name: null,
                    areaName: "Admin",
                    pattern: "Admin/{articlePage:int}",
                    defaults: new { controller = "Home", action = "Index" });

                endpoints.MapAreaControllerRoute(
                    name: null,
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: null,
                    areaName: "User",
                    pattern: "Profile/{controller=Profile}/{action=Index}");

                endpoints.MapControllerRoute(
                    name: null,
                    pattern: "{action}/Page{articlePage:int}",
                    defaults: new { controller = "Home", action = "Index" });

                endpoints.MapControllerRoute(
                    name: null,
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}