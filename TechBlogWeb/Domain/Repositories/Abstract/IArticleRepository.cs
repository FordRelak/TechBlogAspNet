using System;
using System.Linq;
using System.Threading.Tasks;
using TechBlogWeb.Domain.Entites;

namespace TechBlogWeb.Domain.Repositories.Abstract
{
    public interface IArticleRepository
    {
        /// <summary>
        /// Коллекция статей
        /// </summary>
        IQueryable<Article> GetArticles();

        IQueryable<Article> GetArticlesByTag(string tag);

        /// <summary>
        /// Возвращает статью по guid
        /// </summary>
        Article GetArticleById(Guid guid);

        /// <summary>
        /// Удалить статью
        /// </summary>
        /// <param name="id">Обеъкт статьи</param>
        Task DeleteArticleAsync(Guid id);

        /// <summary>
        /// Сохранить изменение в статье/сохранить статью (добавить)
        /// </summary>
        /// <param name="article">Обеъкт статьи</param>
        Task SaveArticleAsync(Article article);
    }
}