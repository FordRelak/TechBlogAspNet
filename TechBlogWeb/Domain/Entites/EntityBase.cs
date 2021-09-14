using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechBlogWeb.Domain.Entites
{
    public class EntityBase
    {
        protected EntityBase() => DateTime = DateTime.UtcNow;

        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Тэг без пробелов
        /// </summary>
        [Display(Name = "Название тэга без пробелов")]
        public virtual string Tag { get; set; }

        /// <summary>
        /// Тэг с пробелами
        /// </summary>
        [Display(Name = "Название тэга с пробелами")]
        public virtual string NormalizedTag { get; set; }

        [Display(Name = "Заголовок")]
        public virtual string Title { get; set; }

        [Display(Name = "Текст")]
        public virtual string Text { get; set; }

        [Display(Name ="Краткое описание")]
        public virtual string SubTitle { get; set; }

        [Display(Name = "Автор")]
        public virtual string Author { get; set; }

        [Display(Name = "Титульная картинка")]
        public virtual string TitleImagePath { get; set; }

        [Display(Name = "SEO title")]
        public string MetaTitle { get; set; }

        [Display(Name = "SEO description")]
        public string MetaDescription { get; set; }

        [Display(Name = "SEO ketwords")]
        public string MetaKeywords { get; set; }

        [DataType(DataType.Time)]
        public DateTime DateTime { get; set; }
    }
}
