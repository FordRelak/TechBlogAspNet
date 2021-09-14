using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechBlogWeb.Domain.Entites;
using TechBlogWeb.Domain.Repositories.Abstract;

namespace TechBlogWeb.Domain.Repositories.EntityFramework
{
    public class EFArticleRepository : IArticleRepository
    {
        private readonly AppDbContext context;

        public EFArticleRepository(AppDbContext context) =>
            this.context = context;

        public IQueryable<Article> GetArticles() => context.Articles; 

        public async Task DeleteArticleAsync(Guid id)
        {
            context.Articles.Remove(new Article() { Id = id });
            await context.SaveChangesAsync();
        }

        public Article GetArticleById(Guid guid)
        {
            return context.Articles.First(a => a.Id == guid);
        }

        public async Task SaveArticleAsync(Article article)
        {
            if (article.Id == default)
                context.Entry(article).State = EntityState.Added;
            else
                context.Entry(article).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public IQueryable<Article> GetArticlesByTag(string tag)
        {
            return context.Articles.Where(a => a.Tag == tag);
        }
    }
}