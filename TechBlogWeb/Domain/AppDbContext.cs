using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TechBlogWeb.Domain.Entites;

namespace TechBlogWeb.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "3BC4D90C-D7B0-47D7-8387-B1DBDECA82CF",
                Name = "user",
                NormalizedName = "USER"
            });

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "AD2CC976-21B4-4A15-9F6D-50B51D23F2AC",
                Name = "admin",
                NormalizedName = "admin".ToUpper()
            });

            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "4D2CE2C5-2C04-42DA-A47D-1DD4A2010723",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "testpassword"),
                SecurityStamp = string.Empty
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "AD2CC976-21B4-4A15-9F6D-50B51D23F2AC",
                UserId = "4D2CE2C5-2C04-42DA-A47D-1DD4A2010723"
            });

            List<Article> articles = new List<Article>();
            StringBuilder normalizedTag = new StringBuilder();
            for (int i = 1; i <= 24; i++)
            {
                normalizedTag.Clear();
                switch (i)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        normalizedTag.Append("Science");
                        break;
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                        normalizedTag.Append("Technology");
                        break;
                    case 9:
                    case 10:
                    case 11:
                    case 12:
                        normalizedTag.Append("Worldwide");
                        break;
                    case 13:
                    case 14:
                    case 15:
                    case 16:
                        normalizedTag.Append("Car News");
                        break;
                    case 17:
                    case 18:
                    case 19:
                    case 20:
                        normalizedTag.Append("Socia lMedia");
                        break;
                    case 21:
                    case 22:
                    case 23:
                    case 24:
                        normalizedTag.Append("Gadgets");
                        break;

                    default:
                        break;
                }
                articles.Add(new Article
                {
                    Id = Guid.NewGuid(),
                    NormalizedTag = normalizedTag.ToString(),
                    Tag = normalizedTag.Replace(" ", "").ToString(),
                    Author = "testAuthor" + i,
                    Title = "testTitle" + i,
                    SubTitle = "testSub" + i,
                    Text = "testText" + i,
                    TitleImagePath = @"tech_menu.jpg"
                });
            }
            
            builder.Entity<Article>().HasData(articles);            
        }
    }
}